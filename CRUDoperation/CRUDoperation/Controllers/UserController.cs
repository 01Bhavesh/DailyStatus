using CRUDoperation.IServiceImplementation;
using CRUDoperation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public ActionResult GetAllUser() 
        {
            Task<IList<User>> lst = _service.GetAllUser();
            return Ok(lst);
        }
        [Route("GetById")]
        [HttpGet]
        public ActionResult GetUserById(int id)
        { 
            Task<User> user = _service.GetUserById(id);
            return Ok(user);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            bool flag = await _service.CreateUser(user);
            if (!flag)
            {
                return BadRequest();
            }
            return Ok();
        }
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult> EditUser(User user)
        {
            bool flag = await _service.UpdateUser(user);
            if (!flag)
            {
                return BadRequest();
            }
            return Ok();
        }
        [Route("Delete")]
        [HttpGet]
        public async Task<ActionResult> DeleteById(int id)
        {
            bool flag = await _service.DeleteUser(id);
            if (!flag)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
