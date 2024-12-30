using System.Collections;
using System.Linq;
using LazyEagerLoading.Models;
using LazyEagerLoading.Server;
using Microsoft.EntityFrameworkCore;

namespace LazyEagerLoading.IService
{
    public class CompanyService
    {
        private readonly DbCompany Db;
        public CompanyService(DbCompany _Db)
        {
            Db = _Db;
        }
        public List<Company> GetCompany()
        {
            List<Company> lst = Db.company.ToList();  // Lazy Loading

            List<Company> eager_lst = Db.company.Include(u => u.Emp).ToList();  //Eager Loading

            foreach (var company in lst)
            {
                company.Emp = Db.employee.Where(u => u.CompanyId == company.Id).ToList();
            }


            //var CompanyCount = lst.Count;
            //for (int i = 0; i < CompanyCount; i++)
            //{
            //    lst[i].Emp = Db.employee.Where(e => e.CompanyId == lst[i].Id).ToList();
            //}
            return lst;
        }
        public Company GetCompanyById(int id)
        {
            Company company = Db.company.Find(id);
            return company;

        }
    }
}
