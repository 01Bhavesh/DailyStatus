using JWTtokenMVC.IServiceImplementation;
using JWTtokenMVC.Models;
using JWTtokenMVC.Models.DTO;
using JWTtokenMVC.ServiceImplemention;
using Microsoft.AspNetCore.Mvc;

namespace JWTtokenMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _iuserService;
        private readonly JwtService _jwtservice;
        public AuthController(IUserService iuserService, IConfiguration configuration)
        {
            _iuserService = iuserService;
            _jwtservice = new JwtService(configuration);
        }
        [HttpPost]
        [Route("/add")]
        public IActionResult AddUser(User user)
        {
            _iuserService.AddUser(user);
            var token = _jwtservice.GenerateToken(user.Name, "user");

            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(60)

            }); 
            return RedirectToAction("GetAllUser", "UserController");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginDTO logindto)
        {
            var token = _jwtservice.GenerateToken(logindto.Name, "user");

            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(60)
            });
            return RedirectToAction("GetAllUser", "UserController");
        }


        [HttpPost]
        [Route("/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Login");
        }
    }

     
    }
