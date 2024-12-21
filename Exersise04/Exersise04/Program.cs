using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersise04
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckConsecutiveNumber();           //Q1
        }
        public static void CheckConsecutiveNumber()
        {
            string str = Console.ReadLine();
            var arr = str.Split('-');
            int num = int.Parse(arr[0]);
            foreach (var i in arr)
            {
                if (num != int.Parse(i))
                {
                    Console.WriteLine("Not Consecutive");
                    break;
                }

            }
            
        }
    }
}
