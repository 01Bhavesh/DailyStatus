using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers
{
    public class BookController : Controller
    {
        private readonly DbCotextApp _db;
        public BookController(DbCotextApp db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var lst = await _db.Books.ToListAsync();
            return View(lst);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _db.Books.AddAsync(book);
            _db.SaveChanges();
            return RedirectToAction("GetAllBook");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(p => p.BookId == id);

            return View(book);
        }
        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
            return RedirectToAction("GetAllBook");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(p => p.BookId == id);

            return View(book);
        }
        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("GetAllBook");
        }

    }
}
