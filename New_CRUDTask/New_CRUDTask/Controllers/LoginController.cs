using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using New_CRUDTask.Model.DTO;
using New_CRUDTask.Server;
using New_CRUDTask.Model;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DbContextServer _db;

        public LoginController(IConfiguration config, DbContextServer db)
        {
            _config = config;
            _db = db;
        }

        [AllowAnonymous] // Allows unauthenticated users to access this endpoint
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var user = Authenticate(login);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = GenerateToken(user);
            return Ok(new { Token = token });
        }

        private User Authenticate(LoginDTO login)
        {
            var currentUser = _db.Users.FirstOrDefault(o =>
            o.FirstName.ToLower() == login.UserName.ToLower() &&
            o.Password == login.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                //new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
