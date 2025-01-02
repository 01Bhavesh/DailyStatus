using EntityFramworkCode.Models;
using EntityFramworkCode.Server;
using EntityFramworkCode.ServiceImplementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityFramworkCode.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly DbProduct _conn;
        public ProductController(IProductService productService, DbProduct conn)
        {
            _productService = productService;
            _conn = conn;
        }
        public async Task<IActionResult> GetProduct(int page = 1, int pagesize = 10)
        {
            var (products, totalcount) = await _productService.GetProducts(page, pagesize);
            ViewBag.currentpage = page;
            ViewBag.totalpages = (int)Math.Ceiling((double)totalcount/pagesize);
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.CategoryList = new SelectList(_conn.categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return RedirectToAction("GetProduct");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            try
            {
                ViewBag.CategoryList = new SelectList(_conn.categories, "CategoryId", "CategoryName");
                var product = await _productService.GetProductById(id);
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("GetProduct");
            }
        }
        [HttpPut]
        public IActionResult Updateproduct(Product product)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("GetProduct");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("GetProduct");
        }
    }
}
