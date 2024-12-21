using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersise02
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count of number from 1 to 100 which are divisible by 3 are: " + DivisibleNumber());

            //Console.WriteLine("Sum of numbers program");    //Q2
            //Addition();

            //Console.WriteLine("Enter number:");             //Q3
            //int num = int.Parse(Console.ReadLine());
            //int factarize = factarization(num);
            //Console.WriteLine("Factorization of number is : " + factarize);

            //GusseNumber();                                    //Q4

            Console.WriteLine("Enter a series of numbers which separated by ' , ' ");
            string str = Console.ReadLine();
            int num = MaxNumber(str);
            Console.WriteLine("Maximum number is: "+num);
        }
        public static int DivisibleNumber()
        {
            int count = 0;
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0)
                { ++count; }
            }
            return count;
        }
        public static void Addition()
        {
          
            int num = 0;
            while (true)
            {
                var number = Console.ReadLine();
                if (number == "ok")
                {
                    Console.WriteLine("sum of number is : " + num);
                    break;
                }
                num = num + int.Parse(number);
            }
        }
        public static int factarization(int num)
        {
            int factor = 1;
            for (int i = 1; i <= num; i++)
            {
                factor = factor * i;
            }
            return factor;
        }

        public static void GusseNumber()
        {
            int i = 1;
            Random random = new Random();
            int gusseNum = random.Next(1, 10);
            do {
                Console.WriteLine("{0} number of chances left : ", 5-i);
                int num = int.Parse(Console.ReadLine());
                //Console.WriteLine(gusseNum);
                if (num == gusseNum)
                {
                    Console.WriteLine("You Won..");
                    break; 
                }
                ++i;
            } while (i <= 4);
            if (i > 4)
            {
                Console.WriteLine("You loss..");
            }
        }
        public static int MaxNumber(string str)
        {
            int num = int.MinValue;
            string[] series = str.Split(',');
            foreach (var i in series)
            {
                if (num < int.Parse(i))
                {
                    num = int.Parse(i);
                }
            }
            return num;
        }
    }
}
