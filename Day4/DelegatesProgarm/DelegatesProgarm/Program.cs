using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesProgarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            //obj.Factors(CallFun);
            //Console.WriteLine("Program.cs");

            obj.sen += Recived1;            // here we are attaching methods to delegate using '+=' operator
            obj.sen += Recived2;
            obj.sen += Recived3;


            Thread t = new Thread(new ThreadStart(obj.Factors));
            t.Start();
            Console.WriteLine("Program.cs");

        }
        //public static void CallFun(int i)
        //{
        //    Console.WriteLine(i);
        //}
        public static void Recived1(int i)      //this are same methods like Recived1 , Recived2 and Recived3
        {
            if(i < 0)
                Console.WriteLine("rec1 : " + i);
        }
        public static void Recived2(int i)
        {
            Console.WriteLine("rec2 : " + i);
        }
        public static void Recived3(int i)
        {
            Console.WriteLine("rec3 : " + i);
        }
    }


    public class MyClass
    {
        //public delegate void CallFun(int i);

        public delegate void Sender(int i);  //crerate delegate
        //public Sender sen = null;            //assign null value
        public event Sender sen = null;         // normal delegate => converted into event

        //public void Factors(CallFun obj)
        //{
        //    for (int i = 0; i <= 10; i++)
        //    {
        //        obj(i);
        //    }        
        //}
        public void Factors()
        {
            for (int i = -2; i <= 5; i++)
            {
                Thread.Sleep(300);
                sen(i);
            }
        }
    }
    
}
