using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SessionStorage.Models;

namespace SessionStorage.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            User user = new User { Id = 1, Name = "Vinay", Password = "1234" };
            HttpContext.Session.SetString("Username" , user.Name);
            string? user_name = HttpContext.Session.GetString("Username");

            ViewData["Username"] = user_name;
            return View();
        }
    }
}
