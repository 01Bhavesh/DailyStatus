using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductCategoryStoreProcedure.Models;
using ProductCategoryStoreProcedure.Server;

namespace ProductCategoryStoreProcedure.Controllers
{
    [Route("[controller]/[action]")]
    //[ApiController] //don't use this
    public class LoginController :  Controller
    {
        private readonly IConfiguration _confi;
        private readonly DbCategory _db;
        public LoginController(IConfiguration confi , DbCategory db)
        {
            _confi = confi;
            _db = db;
        }
        //private User AuthenticateUser(User user)
        //{
        //    User _user = null;
        //    if (user.UserName == "admine" && user.Password == "12345")
        //    {
        //        _user = new User { UserName = "bhavesh", Password =  "12345" };
        //    }
        //    return _user;
        //}
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
                
            };
            var Token = new JwtSecurityToken(_confi["Jwt:Issuer"], _confi["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddMinutes(1),
                signingCredentials:credential
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            IActionResult responce = Unauthorized();
            if (ModelState.IsValid)
            {
                //var user_ = AuthenticateUser(user);
                var user_ = _db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (user_ != null)
                {
                    var tokenvalue = GenerateToken(user_);
                    return Ok(new { token = tokenvalue , User = user_});
                    //if (token != null)
                    //{
                    //    return RedirectToAction("GetAllCategory", "Category");
                    //}
                }
            }

            return responce;
        }
    }
}
