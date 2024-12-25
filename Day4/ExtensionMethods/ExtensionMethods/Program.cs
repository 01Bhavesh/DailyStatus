using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
            var str = post.Shorten(5);
            Console.WriteLine(str);

            List<int> lst = new List<int>();

        }
    }
    
}
