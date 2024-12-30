using System.Diagnostics;
using LazyEagerLoading.Models;
using LazyEagerLoading.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LazyEagerLoading.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbCompany Db;


        public HomeController(ILogger<HomeController> logger, DbCompany _Db)
        {
            _logger = logger;
            Db = _Db;
        }

        public IActionResult Index()
        {
            List<Company> lst = Db.company.ToList();      // Lazy loading

            List<Company> eager_lst = Db.company.Include(u => u.Emp).ToList(); //Eager Loading

            foreach (var company in lst)
            {
                company.Emp = Db.employee.Where(e => e.CompanyId == company.Id).ToList();
            }

            //var CompanyCount = lst.Count;

            //for (int i = 0; i < CompanyCount; i++)
            //{
            //    lst[i].Emp = Db.employee.Where(e => e.CompanyId == lst[i].Id).ToList();
            //}
            
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
