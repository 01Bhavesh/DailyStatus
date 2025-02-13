using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly DbCotextApp _db;
        public AuthorController(DbCotextApp db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<List<Author>> GetAllAuthor()
        {
            var lst = await _db.Authors.ToListAsync();
            return lst;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _db.Authors.AddAsync(author);
            _db.SaveChanges();
            return RedirectToAction("GetAllAuthor");
        }
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
            return Ok("Update successfully");
        }
        [Route("delete")]
        [HttpPost]
        public IActionResult DeleteAauthor(Author author)
        {
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return Ok("delete successfully");
        }
    }
}
