using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_code
{
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "Nimap";
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                Console.WriteLine();
                Console.Write((int)str[i]);
            }
        }
    }
}
