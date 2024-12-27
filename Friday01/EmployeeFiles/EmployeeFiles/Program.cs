using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(1, "Rohit", "Ali-bagh", 1, 20000);
            double sal = emp.Salary;
            Console.WriteLine("salary of Rohit : " + sal);
                Salaried sal_emp = new Salaried(1, "Rohit", "Ali-bagh", 1, 20000, "Cricketer");
            double sal1 = sal_emp.Insentive();
            Console.WriteLine("Salary of Rohit: " + sal1);

            double salariedInsentive = sal_emp.Insentive();
            Console.WriteLine("salariedinsecntive : "+ salariedInsentive);

            double EmployeeInsentive = emp.Insentive();
            Console.WriteLine("EmployeInsentive : "+EmployeeInsentive);

            

        }
    }
}
