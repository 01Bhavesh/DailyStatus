using CrudOperationProject.Model;
using CrudOperationProject.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly DbConn _db;
        public UserController(DbConn db)
        {
            _db = db;
        }
        [Route("Get")]
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var lst = _db.Users
                .ToList();
            return Ok(lst);
        }
        [Route("GetById/{Id}")]
        [HttpGet]
        public IActionResult GetUserById(int Id)
        {
            var p = _db.Users.FirstOrDefault(p => p.Id == Id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }
        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(User user)
        {
            var p = _db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (p == null)
            {
 
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok("User Update successfully");
        }
        [Route("Delete")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var p = _db.Users.FirstOrDefault(p => p.Id == Id);
            _db.SaveChanges();
            return Ok("Delete successfully");
        }
    }
}
