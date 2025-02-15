using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.ServiceImplementation;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("add")]
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            bool flag = _userService.AddUser(user);
            if (!flag)
            {
                return BadRequest(new { message = "User Email is exist" });
            }
            return Ok("User Added sccessfully..");
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllUser(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount) = await _userService.GetUser(page, pagesize);
            return Ok(lst);
        }
        [Route("update")]
        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            _userService.UpdateUser(user);
            return Ok("Updated successfully..");
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok("Deleted successfully..");
        }
    }
}
