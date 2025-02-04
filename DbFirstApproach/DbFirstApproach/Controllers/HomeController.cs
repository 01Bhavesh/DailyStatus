using System.Diagnostics;
using DbFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext datacontext)
        {
            _logger = logger;
            _dataContext = datacontext;
        }
        
        public IActionResult Index()
        {
            //Display all student and with their address from student and student_address tables
            //(select s.namefirst , sa.address from student s inner join student_address sa on s.id = sa.studentID;) 
            var data = (from s in _dataContext.Students
                        select s.Namefirst).ToList();
            ViewData["info"] = data;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
