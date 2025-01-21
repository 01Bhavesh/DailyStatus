using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCategoryStoreProcedure.Models;
using ProductCategoryStoreProcedure.Server;

namespace ProductCategoryStoreProcedure.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly DbCategory _db;
        private readonly IProductItemById _item;
        public ProductController(DbCategory db , IProductItemById item)
        {
            _db = db;
            _item = item;
        }
        public async Task<IActionResult> GetAllProduct()
        {
            ICollection<Product> lst = await _db
                .Products
                .Include(c => c.Category)
                .OrderBy(p => p.ProductId)
                .ToListAsync();
            return View(lst);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
          
            if (_db.Products.Any(p => p.ProductName == product.ProductName))
            {
                TempData["Success"] = "Duplicate Product not allow";
                return RedirectToAction("GetAllProduct");
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            TempData["Success"] = "Product add successfully";
            return RedirectToAction("GetAllProduct");
        }

        public async Task<IActionResult> Update(int Id)
        {
            Product? p = await _db
                .Products
                .FirstOrDefaultAsync(p => p.ProductId == Id);
            ViewBag.CategoryList = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            return View(p);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            TempData["Success"] = "Product Updated successfully";
            return RedirectToAction("GetAllProduct");
        }
        [HttpGet]
        public IActionResult ProductById(int id)
        {
            //Product? product =  await _db.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.ProductId == id);
            Product? product = _item.GetProductById(id);
            Category? category = _db.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            ViewBag.categoryname = category?.CategoryName;
            return View(product);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            Product? p = await _db
                .Products
                .FirstOrDefaultAsync(p => p.ProductId == Id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
            TempData["Success"] = "Product delete successfully";
            return RedirectToAction("GetAllProduct");
        }

    }
}
