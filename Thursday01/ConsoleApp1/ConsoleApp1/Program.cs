using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static Calculate cal = new Calculate();
        static void Main(string[] args)
        {
            //Thread TObj1 = new Thread(fun1);        // threading
            //Thread TObj2 = new Thread(fun2);        // threading
            //TObj1.Start();
            //TObj2.Start();

            Thread obj1 = new Thread(cal.Divide);
            obj1.Start();   // child thread   }      // this is multi threading which might give error
            cal.Divide();    // main thread    }      // so while using multi threading we have to handle that
                                                    // error using lock(this){ .... } , lock(this) will allow
                                                    // only one thread to enter into that selected code

            //Thread t = new Thread(fun1);
            //t.Start();  //foreground thread
            //t.IsBackground = true; // Background thread


            Thread obj = new Thread(Dividing); 


            Console.WriteLine("Main method get ended..");


        }
        public static void fun1()
        {
            Console.WriteLine("Enter into FUN1 function..");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("fun1 "+i.ToString());
            }
            Console.WriteLine("Completed the task FROM FUN1..");
        }

        public static void fun2()
        {
            Console.WriteLine("Enter into FUN2 function..");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("fun2 " + i.ToString());
            }
            Console.WriteLine("Completed the task from fun2..");
        }

        public static void Dividing()
        { 
            
        }

    }
}
