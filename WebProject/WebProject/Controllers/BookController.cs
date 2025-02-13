using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly DbCotextApp _db;
        public BookController(DbCotextApp db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<List<Book>> GetAllBook()
        {
            var lst = await _db.Books.ToListAsync();
            return lst;
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok("Added successfully");
        }


        [Route("update")]
        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
            return Ok("Update successfully");
        }
        [Route("delete")]
        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
            return Ok("Deleted successfully");
        }

    }
}
