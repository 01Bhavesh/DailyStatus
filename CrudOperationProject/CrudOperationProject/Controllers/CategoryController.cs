using CrudOperationProject.Model;
using CrudOperationProject.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DbConn _db;
        public CategoryController(DbConn db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAllCategory() 
        {
            var lst = _db.Categories.Where(c => c.isActive).ToList();
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult GetCategoryById(int Id)
        {
            var c = _db.Categories.FirstOrDefault(c => c.Id == Id);
            if (c != null)
            {
                return Ok(c);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var c = _db.Categories.FirstOrDefault(c => c.CategoryName == category.CategoryName);
            if (c == null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            var c = _db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (c == null)
            {
                return BadRequest();
            }
            _db.Categories.Update(category);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var c = _db.Categories.FirstOrDefault(c => c.Id == Id);
            if (c != null)
            {
                c.isActive = false;
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
