using JWTtokenMVC.IServiceImplementation;
using JWTtokenMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTtokenMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _iuserservice;
        public UserController(IUserService iuserservice)
        {
            _iuserservice = iuserservice;
        }

        [Route("/Add")]
        public IActionResult AddUser(User user)
        {
            _iuserservice.AddUser(user);
            return RedirectToAction("Login");
        }


    }
}
