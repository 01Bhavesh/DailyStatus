using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClassData.Model;
using ClassData.Model.DTO;
using ClassData.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ClassData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbConn _dbConn;
        private readonly IConfiguration _config;
        public LoginController(DbConn db , IConfiguration config)
        {
            _dbConn = db;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDTO user) 
        {
            Registration u = _dbConn.registrations.FirstOrDefault(u => u.FirstName == user.FirstName && u.password == user.Password);
            if (u == null) 
            {
                return NotFound();
            }
            var token = GenerateToken(u);
            return Ok( new {Token = token });
        }
        private string GenerateToken(Registration user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
            {
                new Claim(ClaimTypes.Name , user.FirstName)
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claim,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
