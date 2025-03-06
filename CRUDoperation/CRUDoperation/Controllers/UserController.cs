using CRUDoperation.IServiceImplementation;
using CRUDoperation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var lst = await _service.GetAllUser();
            return Ok(lst);
        }

        [Route("GetById/{id}")] 
        [HttpGet]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(User user)
        {
            bool flag = await _service.CreateUser(user);
            if (!flag)
            {
                return BadRequest("User with this email already exists.");
            }
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [Route("Update")]
        [HttpPut] 
        public async Task<ActionResult> EditUser(User user)
        {
            bool flag = await _service.UpdateUser(user);
            if (!flag)
            {
                return BadRequest("User not found or update failed.");
            }
            return Ok();
        }

        [Route("Delete/{id}")] 
        [HttpDelete] 
        public async Task<ActionResult> DeleteById(int id)
        {
            bool flag = await _service.DeleteUser(id);
            if (!flag)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
