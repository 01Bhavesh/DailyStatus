using LazyEagerLoading.IService;
using LazyEagerLoading.Models;
using Microsoft.AspNetCore.Mvc;

namespace LazyEagerLoading.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService companyDb;
        public CompanyController(CompanyService _companyDb)
        {
            companyDb = _companyDb;
        }
        public IActionResult GetCompany()
        {
            List<Company> lst = companyDb.GetCompany();
            return View(lst);
        }
        public IActionResult GetCompanyById(int id)
        {
            Company company = companyDb.GetCompanyById(id);
            return View(company);
        }
    }
}
