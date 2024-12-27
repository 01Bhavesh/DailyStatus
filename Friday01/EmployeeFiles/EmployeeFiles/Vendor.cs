using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFiles
{
    public class Vendor : Employee
    {
        private double salary { get; set; }
        public Vendor(int id, string name, string address, int _id, double salary) : base(id, name, address, _id, salary)
        {
            this.salary = salary;
        }
        public double Salary
        {
            get { return salary;  }
            set { this.salary = salary; }
        }
        public override double Income()
        {
            return Salary;
        }
    }
}
