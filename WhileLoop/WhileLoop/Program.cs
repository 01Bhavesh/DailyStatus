using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoop
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type your name");
                string name = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine(name);
                    continue;
                }
                break;
            }
        }
    }
}
