using CrudOperationProject.Model;
using CrudOperationProject.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbConn _db;
        public ProductController(DbConn db)
        {
            _db = db;
        }
        [Route("Get")]
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var lst = _db.Products
                .Where(p => p.isActive)
                .Include(p => p.ProductName)
                .ToList();
            return Ok(lst);
        }
        [Route("GetById/{Id}")]
        [HttpGet]
        public IActionResult GetProductById(int Id)
        {
            var p = _db.Products.FirstOrDefault(p => p.Id == Id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var p = _db.Products.Where(p => p.isActive && p.ProductName == product.ProductName);
            if (p == null)
            {
                product.CreatedDate = DateTime.Now;
                _db.Products.Add(product);
                _db.SaveChanges();
            }
            return BadRequest();
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Product product)
        {
                _db.Products.Update(product);
                _db.SaveChanges();
            return Ok("Product Update successfully");        
        }
        [Route("Delete")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var p = _db.Products.FirstOrDefault(p => p.Id == Id);
            p.isActive = false;
            _db.SaveChanges();
            return Ok("Delete successfully");
        }

    }
}
