using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrudOperationProject.Model;
using CrudOperationProject.Model.DTO;
using CrudOperationProject.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CrudOperationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbConn _conn;
        private readonly IConfiguration _config;

        public LoginController(DbConn conn , IConfiguration config)
        {
            _conn = conn;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            User user = _conn.Users.FirstOrDefault(u => u.FirstName == login.FirstName && u.Password == login.Password);
            if (user == null) 
            {
                return BadRequest("User not present..");
            }
            var token = GenerateToken(login);
            return Ok(new { token = token });
        }
        private string GenerateToken(LoginDTO login) 
        {
            var securityToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(securityToken, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name , login.FirstName)
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires:DateTime.UtcNow.AddHours(1),
                signingCredentials:credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
