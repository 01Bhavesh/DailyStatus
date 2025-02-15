using JWTtokenMVC.IServiceImplementation;
using JWTtokenMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTtokenMVC.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private readonly IUserService _iuserservice;
        public UserController(IUserService iuserservice)
        {
            _iuserservice = iuserservice;
        }

        [Route("/GetAllUser")]
        public IActionResult GetAllUser()
        {
            List<User> lst = _iuserservice.GetAllUser();
            return View(lst);
        }


    }
}
