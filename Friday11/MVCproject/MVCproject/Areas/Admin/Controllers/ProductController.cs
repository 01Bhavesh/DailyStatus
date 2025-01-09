using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project.Models;
using Project.Dataaccess.Repository;
using Project.Dataaccess.Server;

namespace MVCproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProduct _db;
        private readonly ApplicationDbContext _conn;
        public ProductController(IProduct db, ApplicationDbContext conn)
        {
            _db = db;
            _conn = conn;
        }
        [HttpGet]

        [Route("/products")]
        public async Task<IActionResult> GetAllProduct()
        {
            var lst = await _db.GetAllProduct();
            if (lst == null)
            {
                return NotFound();
            }
            return View(lst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_conn.Categories, "Id", "Name");
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
                ViewBag.CategoryList = new SelectList(_conn.Categories, "Id", "Name");
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
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            
            _db.Delete(product);
            TempData["success"] = "Product deleted successfully..";
            return RedirectToAction("GetAllProduct");
        }
    }
}
