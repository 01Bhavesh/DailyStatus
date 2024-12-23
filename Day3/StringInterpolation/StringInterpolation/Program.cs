using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Interpolation();        //String interpolation

            string str = "Rohit";
            StringBuilder sb = new StringBuilder(str);
            sb.Append(" Sharma");   //data store in same memory as previously get stored


                
        }
        public static void Interpolation()
        {
            Console.WriteLine("Enter 2 number: ");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Addition of " + num1 + " and " + num2 + " is " + num1 + num2); //instand of addition it will return string 
            Console.WriteLine("Addition of " + num1 + " and " + num2 + " is " + (num1 + num2)); // Concatination happend

            Console.WriteLine("Addition of {0} and {1} is {2}", num1, num2, num1 + num2); // lenghty procces and indexing start with zero and maintain the order

            Console.WriteLine($"Addition of {num1} and {num2} is {num1 + num2}"); // easy way to used

            
        }
    }
}
