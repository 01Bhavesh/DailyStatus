using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Pattern(num);

            int number = int.Parse(Console.ReadLine());
            Pyramid(number);

        }
        public static void Pattern(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                if (i % 10 <= 5 && i % 10 != 0)
                {
                    Console.Write("* ");
                }
                else {
                    Console.Write(i+" ");
                }
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        public static void Pyramid(int number)
        {
            int spcnt = number/2;
            for (int i = 0; i < number; i=i+2)
            {
                for (int j = 0; j < spcnt; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                spcnt = --spcnt;
            }
            
        }
    }
}
