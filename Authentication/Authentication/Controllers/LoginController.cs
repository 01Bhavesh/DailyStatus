using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Model;
using Authentication.Model.LoginDTO;
using Authentication.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbServer _dbServer;
        private readonly IConfiguration _configuration;
        public LoginController(DbServer db , IConfiguration config)
        {
            _dbServer = db;
            _configuration = config;
        }
        [Route("Check")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login login)
        {
            Student student = AuthenticationCheck(login);
            if (student == null)
            {
                return NotFound();
            }
            var token = CreateJwtToken(student);
            return Ok(new { token = token });
        }
        private Student AuthenticationCheck(Login login) 
        {
            return _dbServer.Students.FirstOrDefault(s => s.FirstName == login.FirstName && s.Password == login.Password);
        }
        private string CreateJwtToken(Student student)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentital = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,student.FirstName)
            };
            var token = new JwtSecurityToken
                (
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires:DateTime.UtcNow.AddHours(1),
                    signingCredentials:credentital
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
