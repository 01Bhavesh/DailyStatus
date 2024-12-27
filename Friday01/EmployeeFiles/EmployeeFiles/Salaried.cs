using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFiles
{
    public class Salaried : Employee
    {
        public  string Field { get; set; }
        public double Salary { get; set; }
        public Salaried(int id, string name, string address, int _id, double salary, string field) : base(id, name, address, _id, salary)
        {
            Field = field;
            this.Salary = salary;
        }
        public override double Insentive()
        {
            return Salary + 5000*1;
        }
        public override double Income()
        {
            return this.Insentive() + Salary;
        }
    }
}
