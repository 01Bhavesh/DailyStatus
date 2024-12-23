using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSalariedEmployee
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(1,"Rohit","Sharma",50000);

            Console.WriteLine(emp.Salary());
            
        }

    }
}
