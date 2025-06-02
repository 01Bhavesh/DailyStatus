using CRUDoperationPractice.Model;
using CRUDoperationPractice.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperationPractice.Controllers
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
            var lst = _db.GetAll();
            return Ok(lst);
        }
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _db.Create(student);
            return Ok();
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _db.Update(student);
            return Ok();
        }
        [Route("Delete")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _db.Delete(Id);
            return Ok();
        }
    }
}
