using LazyEagerLoading.IService;
using LazyEagerLoading.Models;
using Microsoft.AspNetCore.Mvc;

namespace LazyEagerLoading.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeDb;
        public EmployeeController(EmployeeService _employeeDb)
        {
            employeeDb = _employeeDb;
        }
        public IActionResult GetEmployee()
        {
            IEnumerable<Employee> lst = employeeDb.GetEmployees();
            return View(lst);
        }
    }
}
