using Microsoft.EntityFrameworkCore;

using SessionStoragePractice.Models;
using Login = SessionStoragePractice.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SessionStoragePractice.Controllers
{
    public class UserController : Controller
    {
        private readonly DbUserContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(DbUserContext db , IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            //var userName = HttpContext.Session.GetString("UserName");
            var userName = HttpContext.Session.GetString("Username");

            //if (string.IsNullOrEmpty(userName))
            //{
            //    return RedirectToAction("Login");
            //}

            // Pass the user name to the view
            ViewData["UserName"] = userName;

            List<User> users = await _db.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {

            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("GetAllUser");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login user)
        {
            IActionResult response = Unauthorized();

            if (ModelState.IsValid)
            {
                var _user = _db.Users.FirstOrDefault(u => u.Username == user.UserName && u.Password == user.Password);

                if (_user != null)
                {
                    // Set the session data
                    HttpContext.Session.SetString("Username", _user.Username);


                    return RedirectToAction("GetAllUser");
                }
            }

            return response;
        }

    }

   
}
