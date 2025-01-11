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
            int x = 10; // when REF is use that time we have to initialize value of variables
                        // before passing argument in method
            int y = 10;
            //Swapping(x, y);       //call by value
            int a ;  //using OUT keyword we may or may not have to initialize
                     //value of variable
            dynamic str = 10;
            string str1 = "bhavesh";
            string str2 = "bhavesh";
            string str4 = new string("bhavesh".ToCharArray());
            char[] ch = { 'b', 'h', 'a', 'v', 'e', 's', 'h' };
            string str3 = new string(ch);
            //int[] arr = new int[5] { 1, 2, 3, 4,5 };
            Console.WriteLine(str1 == str3);
            Console.WriteLine(str2 == str4);
            Console.WriteLine(str1.Equals(str3));
            //Console.WriteLine(a.GetType());
            //Console.WriteLine(str.GetType());
            //str = "bhavesh";
            //Console.WriteLine(str.GetType());

          

            Swapping(ref x, ref y, out a);
            Console.WriteLine(a);

            //Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
        }
        //public static void Swapping(int x, int y)
        //{
        //    x = x + y;
        //    y = x - y;
        //    x = x - y;
        //    Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
        //}


        public static void Swapping(ref int x, ref int y, out int a)
        {
            Console.WriteLine($"Swap value of 'x = ' {x} and 'y = ' {y}");
            x = x + y;
            y = x - y;
            x = x - y;
            a = x + y;

        }
    }
}
