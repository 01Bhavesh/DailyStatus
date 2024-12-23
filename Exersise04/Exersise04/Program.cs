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

            //bool status = CheckConsecutiveNumber();           //Q1
            //if (status)
            //{
            //    Console.WriteLine("Consecutive");
            //}
            //else
            //{
            //    Console.WriteLine("Not Consecutive");
            //}

            //CheckDuplicateNumber();                         //Q2 

            //TimeValidation();                                 //Q3

        }
        public static bool CheckConsecutiveNumber()
        {
            Console.WriteLine("enter number separating by '-' :");
            string str = Console.ReadLine();
            var arr = str.Split('-');
            int num = int.Parse(arr[0]);
            for(int i = 1 ; i < arr.Length; i++)
            {
                if (num != int.Parse(arr[i]) - 1)
                {
                    return false;
                }
                num = int.Parse(arr[i]);
            }
            return true;
        }
        public static void CheckDuplicateNumber()
        {
            Console.WriteLine("enter number separating by '-' :");
            string str = Console.ReadLine();
            var arr = str.Split('-');
            int[] number = new int[arr.Length];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = int.Parse(arr[i]);
            }
            Array.Sort(number);
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == number[i - 1])
                {
                    Console.WriteLine(number[i-1]);
                    i++;
                }
            }
        }
        //public static void TimeValidation()
        //{
        //    Console.WriteLine("enter time in formate of 'Hr:Min' : ");
        //    string str = Console.ReadLine();
        //    var time = Convert.ToDateTime(str);
        //    Console.WriteLine(time);
        //    if(time)
        //}
    }
}
