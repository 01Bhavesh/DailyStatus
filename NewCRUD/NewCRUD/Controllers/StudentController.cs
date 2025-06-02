using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCRUD.IService;
using NewCRUD.Model;

namespace NewCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _db;
        public StudentController(IStudentService db)
        {
            _db = db;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> lst = _db.GetAll();
            return Ok(lst);
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _db.Add(student);
            return Ok();
        }
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Delete(Id);
            return Ok();
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _db.Update(student);
            return Ok();
        }
        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            Student std = _db.GetById(Id);
            return Ok(std);
        }
    }
}
