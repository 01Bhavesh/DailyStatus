using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_RefParameters
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 20;
            int y = 10;
            //Swapping(x, y);       //call by value

            Swapping(ref x, ref y);

            Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
        }
        //public static void Swapping(int x, int y)
        //{
        //    x = x + y;
        //    y = x - y;
        //    x = x - y;
        //    Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
        //}


        public static void Swapping(ref int x, ref int y)
        {
            Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
            x = x + y;
            y = x - y;
            x = x - y;
            
        }
    }
}
