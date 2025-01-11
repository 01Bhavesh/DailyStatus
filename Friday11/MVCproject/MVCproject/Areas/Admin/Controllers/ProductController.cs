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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProduct db, ApplicationDbContext conn, IWebHostEnvironment webHost)
        {
            _db = db;
            _conn = conn;
            _webHostEnvironment = webHost;
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
        public IActionResult Create(Product product, IFormFile file)
        {
                string fileName = null;
                string wwwroot = _webHostEnvironment.WebRootPath;  //find path of wwwroot file
                if (file != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // random name + extension of file
                    string pathName = Path.Combine(wwwroot, @"images\Product"); //combine path of wwwroot and image\Product
                    using (var filePath = new FileStream(Path.Combine(pathName, fileName), FileMode.Create)) // create file
                    {
                        file.CopyTo(filePath); // copy image into filepath
                    }
                    //_conn.Products.Add()  //ImageUrl = @"\images\Product\" + fileName;

                }

                var products = new Product();
                products.Id = product.Id;
                products.Title = product.Title;
                products.Description = product.Description;
                products.ISBN = product.ISBN;
                products.Author = product.Author;
                products.ListPrice = product.ListPrice;
                products.Price = product.Price;
                products.Price50 = product.Price50;
                products.Price100 = product.Price100;
                products.CategoryId = product.CategoryId;
                products.Category = product.Category;
                products.ImageUrl = @"\images\Product\" + fileName;


                _db.Add(products);
                TempData["success"] = "Product added successfully.."; // Use to show data on UI
                return RedirectToAction("GetAllProduct");
            
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
        public IActionResult Edit(Product product, IFormFile file)
        {
            string fileName = null;
            string wwwroot = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // random name + extension of file
                string pathName = Path.Combine(wwwroot, @"images\Product");
                using (var filePath = new FileStream(Path.Combine(pathName, fileName), FileMode.Create))
                {
                    file.CopyTo(filePath);
                }
                //_conn.Products.Add()  //ImageUrl = @"\images\Product\" + fileName;

            }

            var products = new Product();
            products.Id = product.Id;
            products.Title = product.Title;
            products.Description = product.Description;
            products.ISBN = product.ISBN;
            products.Author = product.Author;
            products.ListPrice = product.ListPrice;
            products.Price = product.Price;
            products.Price50 = product.Price50;
            products.Price100 = product.Price100;
            products.CategoryId = product.CategoryId;
            products.Category = product.Category;
            products.ImageUrl = @"\images\Product\" + fileName;

            _db.Update(products);
                TempData["success"] = "Product updated successfully..";
                return RedirectToAction("GetAllProduct");
           
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
