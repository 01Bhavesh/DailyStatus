using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monday01
{
    public class Program
    {
        static void Main(string[] args)         //Entery point method
        {
            Person p1 = new Person(1,"Rohit","Sharma");    //Object
            Person p2 = new Person(2, "Virat", "Kohli");
            Console.WriteLine(p1.FirstName);
            //Console.WriteLine(p1.Id);                 //private variable not accepted
            p1 = new Person("Cricketer");               //use of Constructor overloading
            p2 = new Person("Cricketer");

            Console.WriteLine("Player salary without IPL salary : "+p1.PlayerSalary());        //use of parameterless method overloading
            Console.WriteLine("Player salary with IPL salary : " + p1.PlayerSalary(60000));    //use of parameterize method overloading    


            Main(10);       //overloaded Main(int) method called through entry point main() method 
        }
        static void Main(int i)         //Overloaded main method
        {
            Console.WriteLine(i);
        }
    }
}
