using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionBasicTokenChecking.Models;

namespace SessionBasicTokenChecking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private readonly DbContextAuth _dbContextAuth;
   

        public UserController(DbContextAuth dbContextAuth)
        {
            _dbContextAuth = dbContextAuth;
        }
        [HttpGet]
        public  User? GetUser(string username)
        {
            User? u = null;
            var _userName = HttpContext.Session.GetString("User");
            if (username == _userName)
            {
                u = _dbContextAuth.users.FirstOrDefault(u => u.Name == username);
                return u;
            }
            return u;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _dbContextAuth.users.Add(user);
            _dbContextAuth.SaveChanges();
            return Ok();
        }


        [Route("/Login")]
        [HttpPost]
        public IActionResult Login(Login _user)
        {


            User? user = _dbContextAuth.users.FirstOrDefault(u => u.Name == _user.Name
                                                            && u.Password == _user.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Name);
                return Ok(" Found Succesfully");

            }

            return NotFound();
        }

    }
}
