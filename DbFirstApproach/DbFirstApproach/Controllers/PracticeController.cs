using Microsoft.AspNetCore.Mvc;

namespace DbFirstApproach.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
