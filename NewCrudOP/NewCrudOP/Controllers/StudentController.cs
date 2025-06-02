using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrudOP.IService;
using NewCrudOP.Model;

namespace NewCrudOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _db;
        public StudentController(IStudent db)
        {
            _db = db;
        }
        [Route("/GetAll")]
        [HttpGet]
        public ActionResult GetAll() 
        {
            List<Student> std = _db.GetAll();
            return Ok(std);    
        }
        [Route("/Add")]
        [HttpPost]
        public ActionResult Add(Student student)
        {
            _db.Add(student);
            return Ok();
        }
        [Route("/Update")]
        [HttpPost]
        public ActionResult Update(Student student)
        {
            _db.Update(student);
            return Ok();
        }
        [Route("/Delete/{Id}")]
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _db.Delete(Id);
            return Ok();
        }
    }
}
