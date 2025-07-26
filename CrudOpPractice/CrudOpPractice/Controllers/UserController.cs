using CrudOpPractice.IUserService;
using CrudOpPractice.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOpPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserImplementation _conn;
        public UserController(IUserImplementation conn)
        {
            _conn = conn;
        }
        [Route("Get")]
        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> lst = _conn.GetAll();
            return Ok(lst); 
        }
        [Route("GetById/{Id}")]
        [HttpGet]
        public ActionResult GetById(int Id)
        { 
            User user = _conn.GetById(Id);
            return Ok(user);
        }
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(User user)
        { 
            _conn.Create(user);
            return Ok();
        }
        [Route("Delete/{Id}")]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _conn.Delete(Id);
            return Ok();
        }
        [Route("Update")]
        [HttpPost]
        public ActionResult Update(User user)
        { 
            _conn.Update(user);
            return Ok();
        }
    }
}
