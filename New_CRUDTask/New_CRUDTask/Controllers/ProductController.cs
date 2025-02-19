using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.ExceptionHandling;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("add")]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product); ;
                return Ok(new { message = "Product is added successfully." });
            }
            catch (TaskException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
            }
        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllProduct(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount)  =  await _productService.GetProducts(page,pagesize);
            return Ok(lst);
        }
        [Route("update")]
        [HttpPost]
        public ActionResult UpdateProduct(Product product) 
        {
            _productService.UpdateProduct(product);
            return Ok("Updated successfully..");

        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteProduct(int id) 
        {
            try { 
            _productService.DeleteProduct(id);
            return Ok("Deleted successfully..");
                }
            catch (TaskException ex)
                {
                    return BadRequest(new { message = ex.Message});
                }
            catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Unexpected error...", error = ex.Message });
                };
        }
    }
}
