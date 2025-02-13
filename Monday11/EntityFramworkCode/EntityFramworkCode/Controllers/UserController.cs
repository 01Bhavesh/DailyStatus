using EntityFramworkCode.Models;
using EntityFramworkCode.Models.DTO;
using EntityFramworkCode.Server;
using EntityFramworkCode.ServiceImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramworkCode.Controllers
{
    public class UserController : Controller
    {
        private readonly DbProduct _db;
      
        public UserController(DbProduct db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult User()
        {
             return View();
        }
        [HttpPost]
        public IActionResult User(User user)
        {
            string password = EncryptionDecryption.Encryption(user.Password);
            HttpContext.Session.SetString("password", password);
            user.Password = password;
            _db.users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            string? pswd = HttpContext.Session.GetString("password");
            if (pswd != null)
            {
                HttpContext.Session.Clear();
                if (loginUser.Password == EncryptionDecryption.Decryption(pswd))
                {
                    return RedirectToAction("GetCategory", "Category");
                }
            }
            else
            {
                User? u = _db.users.FirstOrDefault(u => u.Email == loginUser.Email);
                pswd = EncryptionDecryption.Decryption(u.Password);
                if (pswd == loginUser.Password)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("GetCategory", "Category");
                }
            }
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }

    }
}
