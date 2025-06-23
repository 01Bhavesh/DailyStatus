using ClassData.Model;
using ClassData.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClassData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly DbConn _dbConn;
        public RegistrationController(DbConn db)
        {
            _dbConn = db;
        }
        [Route("/create")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Registration user)
        {
            Registration u = _dbConn.registrations.FirstOrDefault(u => u.FirstName == user.FirstName && u.password == user.password);
            if (u != null) 
            {
                return Ok("User already present..");
            }
            _dbConn.registrations.Add(user);
            _dbConn.SaveChanges();
            return Ok();
        }
        [Route("/update")]
        [HttpPost]
        public ActionResult UpdateData(Registration user)
        {
            _dbConn.registrations.Update(user);
            _dbConn.SaveChanges();
            return Ok();
        }
    }
}
