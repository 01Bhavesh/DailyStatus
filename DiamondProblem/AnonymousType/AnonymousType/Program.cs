using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousType
{
    public class Program
    {
        static void Main(string[] args)
        {
            var str = new { id = 1, name = "bhavesh" };//Anonymous types contain one or more
                                                       //public read-only properties.
                                                       //No other kinds of class members,
                                                       //such as methods or events, are
                                                       //valid.
        }
    }
}
