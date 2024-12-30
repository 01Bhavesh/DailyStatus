using LazyEagerLoading.Models;
using LazyEagerLoading.Server;

namespace LazyEagerLoading.IService
{
    public class EmployeeService
    {
        private readonly DbCompany db;
        public EmployeeService(DbCompany _db)
        {
            db = _db;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return GetEmployees(db);
        }

        public IEnumerable<Employee> GetEmployees(DbCompany db)
        {
            List<Employee> lst = db.employee.ToList();
            IEnumerable<Employee> elst = (IEnumerable<Employee>)lst;
            return elst;
        }
    }
}
