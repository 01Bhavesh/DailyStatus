using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutableString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Note book";       //Data store in heap section 
            Console.WriteLine(str);
            str = str + " Hand book";        //new memory allocated to storing data
            Console.WriteLine(str);

            string name = "Virat";
            StringBuilder sb = new StringBuilder(name);         //name data  store in stringbuilder
            sb.Append(" Kohli");                    // data append in same memory
            Console.WriteLine(sb);

        }
    }
}
