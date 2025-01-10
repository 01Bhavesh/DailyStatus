using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await
{
    public class Program
    {
        static void Main(string[] args)
        {
            Print();         // it will move to next line code as we using async and await
                             //print() method is not execute , it will execute after 10 second 
            Factor(4);       // this code will executed as main thread is executing
            Console.WriteLine("end of application");
            

            PrimeNumber();

            Console.ReadLine();                 // why we use ReadLine() beacause if we not use readline()
                                                // then MAIN THREAD GET ALREADY EXECUTED , and we not able
                                                // to see async and await executed code

            Factor(5);

        }
        public static async void Print()
        {
             //await Task.Run(new Action(Add));        //async and await use i pair , it will wait until task
                                                    //get executed then move to next line code execution  
            Console.WriteLine(" hello...");
        }
        public static void Add()
        {
            Thread.Sleep(200);
        }
        public static void Factor(int count)
        {
            int num = 1;
            for (int i = 1; i <= count; i++)
            {
                num = num * i;
            }
            Console.WriteLine(num);
        }

        public static void PrimeNumber()
        {
            List<int> arr = new List<int>(); 
            for(int i = 2; i < 100; i++)
            {
                bool flag = false;
                for (int j = 2; j < i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                //int a = 0;                //Main() method will get execute 
                //Console.WriteLine(i/a);
                if (!flag)
                {
                    arr.Add(i);
                }
            }
            foreach (int i in arr)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
