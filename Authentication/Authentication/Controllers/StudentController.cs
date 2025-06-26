using Authentication.IServiceImplementation;
using Authentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        { 
            List<Student> lst = _studentService.GetAll();
            return Ok(lst);
        }
        [Route("GetById/{Id}")]
        [HttpGet]
        public ActionResult GetById(int Id)
        {
            Student s = _studentService.GetById(Id);
            return Ok(s);
        }
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Student student)
        {
            bool flag = _studentService.Create(student);
            if (flag)
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }
        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Student student)
        {
            _studentService.Update(student);
            return Ok();
        }
        [Route("Delete/{Id}")]
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _studentService.Delete(Id);
            return Ok();
        }
    }
}
