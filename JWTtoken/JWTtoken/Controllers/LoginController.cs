using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JWTtoken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTtoken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _confi;
        public LoginController(IConfiguration confi)
        {
            _confi = confi;
        }
        private User AuthenticateUser(User user)
        {
            User _user = null;
            if (user.Username == "Admin" && user.Password == "12345")
            {
                _user = new User ("Bhavesh" , "1234");
            }
            return _user;
        }
        private string GenerateToken(User user)
        {
            var securetyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["Jwt:Key"]));
            var credential = new SigningCredentials(securetyKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_confi["Jwt:Issuer"], _confi["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if (user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new { token = token });
            }
            return response;
        }
        [AllowAnonymous]
        [Route("/getUser")]
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return (IEnumerable<User>)new List<User> {  new User ( "bhavesh", "1234"),
                new User ( "Deepak" , "5678"),
                new User("Maayur" ,"2345"),
                new User("Vinay", "6789")

            };
        }
    }
}
