using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_review.IServiceImplementation;
using task_review.Model;

namespace task_review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _db;
        public ProductController(IProductService db)
        {
            _db = db;
        }
        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAllProduct() {
            List<Product> lst = _db.GetAllProduct();
            return Ok(lst);
        }
        [Route("Create")]
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            bool flag =  _db.CreateProduct(product);
            if (flag)
            {
                return Ok();
            }
            return NoContent();
            
        }
        [Route("Update")]
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _db.UpdateProduct(product);
            return Ok();
        }
        [Route("Delete")]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            _db.DeleteProductById(id);
            return Ok();
        }
        [Route("GetAllById")]
        [HttpGet]
        public ActionResult GetByIdProduct(int id)
        {
            Product pro = _db.GetProductById(id);
            return Ok(pro);
        }
    }
}
