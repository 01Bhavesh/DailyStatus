using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Divisible div = new Divisible();
            div.divided(5,0);

            Person p = new Person(1,"Rohit");
            Person p1 = new Person(1, null);

            try
            {
                div.GetPerson();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
