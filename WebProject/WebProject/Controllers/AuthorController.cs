using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DbCotextApp _db;
        public AuthorController(DbCotextApp db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var lst = await _db.Authors.ToListAsync();
            return View(lst);
        }

        [HttpGet]
        public IActionResult AdAauthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _db.Authors.AddAsync(author);
            _db.SaveChanges();
            return RedirectToAction("GetAllAuthor");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(p => p.AuthorId == id);

            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("GetAllAuthor");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(p => p.AuthorId == id);

            return View(author);
        }
        [HttpPost]
        public IActionResult DeleteAauthor(Author author)
        {
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("GetAllAuthor");
        }
    }
}
