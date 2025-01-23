using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategoryStoreProcedure.Models;
using ProductCategoryStoreProcedure.Server;

namespace ProductCategoryStoreProcedure.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly DbCategory _db;
        private readonly ICategoryStoreProcedure _cat;
        public CategoryController(DbCategory db , ICategoryStoreProcedure cat)
        {
            _db = db;
            _cat = cat;
        }
        //[Route("/Categories")]
        [Authorize]
        public async Task<IActionResult> GetAllCategory()
        {
            //ICollection<Category> lst = await _db                             //using lambda expression
            //                                    .Categories
            //                                    .OrderBy(c => c.CategoryId)
            //                                    .ToListAsync();
            IList<Category> lst = _cat.AllCategories();

            return View(lst);
        }
        //[Route("/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_db.Categories.Any(c => c.CategoryName == category.CategoryName))
            {
                TempData["Success"] = "Duplicate category not allow";
                return RedirectToAction("GetAllCategory");
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Added successfully..";
            return RedirectToAction("GetAllCategory");
        }

        public async Task<IActionResult> Update(int Id)
        {
            Category? category = await _db
                .Categories
                .FirstOrDefaultAsync(p => p.CategoryId == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["Success"] = "Category updated successfully..";
            return RedirectToAction("GetAllCategory");
        }
    
        public async Task<IActionResult> Delete(int Id)
        {
            Category? category = await _db
                .Categories
                .FirstOrDefaultAsync(p => p.CategoryId == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully..";
            return RedirectToAction("GetAllCategory");
        }
    }
}
