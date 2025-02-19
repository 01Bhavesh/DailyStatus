using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.ExceptionHandling;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.ServiceImplementation;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("add")]
        [HttpPost]
        public ActionResult CreateProduct(Category category)
        {
            try { 
            _categoryService.AddCategory(category);
            return Ok("Category Added sccessfully..");
            }
            catch (TaskException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllCategory(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount) = await _categoryService.GetCategory(page, pagesize);
            return Ok(lst);
        }
        [Route("update")]
        [HttpPost]
        public ActionResult UpdateProduct(Category category)
        {
            try { 
            _categoryService.UpdateCategory(category);
            return Ok("Updated successfully..");
            }
            catch (TaskException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok("Deleted successfully..");
        }
    }
}
