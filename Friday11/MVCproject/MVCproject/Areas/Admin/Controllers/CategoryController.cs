using Microsoft.AspNetCore.Mvc;
using project.Models;
using Project.Dataaccess.Repository;




namespace MVCproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategory _db;
        public CategoryController(ICategory db)
        {
            _db = db;
        }

        [Route("/categories")]
        public async Task<IActionResult> GetCategory()
        {
            var lst = await _db.GetCategory();
            if (lst == null)
            {
                return NotFound();
            }
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
                _db.Add(category);
                TempData["success"] = "Category added successfully.."; // Use to show data on UI
                return RedirectToAction("GetCategory");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            Category? category = await _db.GetCategoryById(Id); // use with all properties
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
                _db.Update(category);
                TempData["success"] = "Category updated successfully..";
                return RedirectToAction("GetCategory");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            //Category? category = _db.categories.Find(Id); // use only with primary key property
            Category category = await _db.GetCategoryById(Id);
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
            _db.Delete(category);
            TempData["success"] = "Category deleted successfully..";
            return RedirectToAction("GetCategory");
        }
        
    }
}
