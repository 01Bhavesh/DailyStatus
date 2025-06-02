using CRUDoperation.Model;
using CRUDoperation.Model.DTO;
using CRUDoperation.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var CurrentUser = Authenticate(user);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var token = GenerateToken(user);
            return Ok(new { Token = token }); 

        }
        private User Authenticate(UserDTO login)
        {
            var currentUser = _db.Users.FirstOrDefault(o =>
            o.Name.ToLower() == login.Name.ToLower() &&
            o.Password == login.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
        private string GenerateToken(UserDTO user) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
