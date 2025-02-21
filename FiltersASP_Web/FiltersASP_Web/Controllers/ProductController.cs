using FiltersASP_Web.IServiceImplementation;
using FiltersASP_Web.Model;
using FiltersASP_Web.ServiceImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiltersASP_Web.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _p;
        public ProductController(IProductService p)
        {
            _p = p;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllProduct() 
        {
            return Ok(_p.GetProduct());
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct(Product product) 
        {
            _p.AddProduct(product);
            return Ok();
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_p.GetProductById(id));
        }
    }
}
