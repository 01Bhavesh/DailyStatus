using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserLoginPage.Models;

namespace UserLoginPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _confi;
        public LoginController(IConfiguration confi)
        {
            _confi = confi;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["Jwt:Key"]));
            //symmettric encryption key which is used to sign and validate JWT token
            var credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            //uses this key to specify the signing alogorithm
            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname , user.Surname),
                new Claim(ClaimTypes.Role , user.Role)
            };

            var token = new JwtSecurityToken(_confi["Jwt:Issuer"],
                _confi["Jwt:Audience"],
                claim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserContest.Users.FirstOrDefault(o =>
            o.Username.ToLower() == userLogin.Username.ToLower() &&
            o.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
