using CRUDoperation.Model.DTO;
using CRUDoperation.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DbProduct _db;
        public LoginController(IConfiguration config , DbProduct db)
        {
            _configuration = config;
            _db = db;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            var CurrentUser = Autheticate(user);
        }
    }
}
