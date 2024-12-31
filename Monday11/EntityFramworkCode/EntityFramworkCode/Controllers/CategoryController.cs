using EntityFramworkCode.Models;
using EntityFramworkCode.ServiceImplementation;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramworkCode.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> GetCategory(int page = 1, int pagesize = 10)
        {
            var (category, totalcount) = await _categoryService.GetCategorie(page, pagesize);
            ViewBag.currentpage = page;
            ViewBag.totalpage = (int)Math.Ceiling((double)totalcount / pagesize);
            return View(category);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.AddCategory(category);
                return RedirectToAction("GetCategory");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category);
            }
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("GetCategory");
        }
        public IActionResult DeleteCategoryById(int Id)
        {
            _categoryService.DeleteCategoryById(Id);
            return RedirectToAction("GetCategory");
        }
    }
}
