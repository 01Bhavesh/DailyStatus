using Microsoft.AspNetCore.Mvc;
using project.Models;
using Project.Dataaccess.Server;




namespace project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult GetCategory()
        {
            List<Category> lst = _db.categories.ToList();
            return View(lst);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == null || category.DisplayOrder == 0)
            {
                ModelState.AddModelError("", "Null value is not allowed");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category added successfully.."; // Use to show data on UI
                return RedirectToAction("GetCategory");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Category? category = _db.categories.FirstOrDefault(c => c.Id == Id); // use with all properties
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                return View(category);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            
            if (ModelState.IsValid)
            {
                _db.categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully..";
                return RedirectToAction("GetCategory");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Category? category = _db.categories.Find(Id); // use only with primary key property
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                return View(category);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            _db.categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully..";
            return RedirectToAction("GetCategory");
        }
    }
}
