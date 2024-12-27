using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecodHeighestWord
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the string which conteain more tha 1 word: ");
            string str = Console.ReadLine();
            secondHeighestWord(str);
        }
        public static void secondHeighestWord(string str)
        {
            var arr = str.Split(' ');
            int first = int.MinValue;
            int second = int.MinValue;
            foreach (var i in arr)
            {
                if (i.Length > first)
                {
                    second = first;
                    first = i.Length;
                }
                else if (i.Length > second)
                {
                    second = i.Length;
                }
            }
            foreach (var i in arr)
            {
                if (i.Length == second)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
