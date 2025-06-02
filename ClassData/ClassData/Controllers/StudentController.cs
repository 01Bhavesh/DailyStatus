using ClassData.IServiceImplemetation;
using ClassData.Model;
using ClassData.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _conn;
        public StudentController(IStudent conn)
        {
            _conn = conn;
        }
        [Route("/GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Student> lst = _conn.GetAll();
            return Ok(lst);
        }
        [Route("/Add")]
        [HttpPost]
        public ActionResult Add(Student student)
        { 
            _conn.Add(student);
            return Ok();
        }
        [Route("/Delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            _conn.Delete(id);
            return Ok();
        }
        [Route("/GetById/{id}")]
        [HttpGet]
        public ActionResult Get(int id) 
        {
            Student std = _conn.GetById(id);
            return Ok(std);
        }
        [Route("/Update")]
        [HttpPost]
        public ActionResult Update(Student student) 
        {
            _conn.Update(student);
            return Ok();
        }
    }
}
