
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondProblemSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            Employee emp = new Employee(1);
            emp.Name();
            Vendar v = new Vendar(2);
            v.Name();
            Salary sal = new Salary(2);
            sal.Name();

            Employee val = new Salary(3);
            val.Name();


            
        }
    }
}
