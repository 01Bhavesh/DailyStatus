using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTtoken.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("getdata")]
        public string GetData()
        {
            return "Data will recived after I understand this token";
        }
    }
}
