using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAndCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            CheckPrime(num);
            string str = Console.ReadLine();
            ReverseString(str);
            Pattern(num);
            PiramidPattern(num);
        }
        public static void CheckPrime(int num) 
        {
            bool flag = false;
            for (int i = 2; i <= num / 2; i++)
            {
                
                if (num % i == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("It is not prime");
            }
            else 
            {
                Console.WriteLine("It is prime");
            }
        }
        public static void ReverseString(string str) 
        {
            string result = "";
            for (int i = str.Length-1; i >= 0; i--)
            {
                result = result + str[i];
            }
            foreach (char ch in result)
            {
                Console.WriteLine(ch);
            }
        }
        public static void Pattern(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void PiramidPattern(int num)
        {
            int spcount = num / 2;
            for (int i = 0; i < num; i = i + 2)
            {
                for (int j = 0; j < spcount; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                --spcount;
            }
        }
    }
}
