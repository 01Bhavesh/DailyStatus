using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Lambda
{
    //public delegate void MyDelegate(int val); // delegate
    public delegate int MyDelegate(int val); // delegate
    public class Program
    {
        //public delegate int MyDelegate(int val);
        public static void sender(int val)
        {
            val = val * val;
            Console.WriteLine(val);
        }
        static void Main(string[] args)
        {
            //MyDelegate obj = new MyDelegate(Program.sender);  //we attached method reference to delegate
            //obj(5); //using delegate reference we calling method


            //MyDelegate obj = delegate (int val)       //anonymous function
            //{                                         // use with delegate name + datatype should be mention
            //    val = val * val;
            //    Console.WriteLine(val);
            //};
            //obj(10);
            //obj.Invoke(20);



            //MyDelegate obj = (val) =>         //lambda expression
            //{                                 //not use delegate name + datatype is not mention
            //    val = val * val;
            //    Console.WriteLine(val);
            //};
            //obj.Invoke(10);


            MyDelegate obj = (val) => { return val = val * val; };
            Console.WriteLine(obj.Invoke(10));
            
        }
    }
}
