using Microsoft.AspNetCore.Mvc;
using project.Models;
using Project.Dataaccess.Repository;

namespace MVCproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProduct _db;
        public ProductController(IProduct db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var lst = _db.GetAllProduct();
            if (lst == null)
            {
                return NotFound();
            }
            return View(lst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                TempData["success"] = "Product added successfully.."; // Use to show data on UI
                return RedirectToAction("GetAllProduct");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {
            Product product = await _db.GetProductById(Id);
            if (product == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                return View(product);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product);
                TempData["success"] = "Product updated successfully..";
                return RedirectToAction("GetAllProduct");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Product product = await _db.GetProductById(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }
            _db.Delete(product);
            TempData["success"] = "Product deleted successfully..";
            return RedirectToAction("GetAllProduct");
        }
    }
}
