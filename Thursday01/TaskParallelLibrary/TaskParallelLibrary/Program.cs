using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Thread obj1 = new Thread(Divid);
            //obj1.Start();
            //Thread obj2 = new Thread(Add);
            //obj2.Start();
            Task obj1 = new Task(Divid);
            //obj1.RunSynchronously();      // when you run application then that particular task/thread
             //is going to excecuted.
            obj1.Start();
            Task obj2 = new Task(Add);
            obj2.RunSynchronously(); //single thread initiating/doing mutliple task
            //obj2.Start();             //after complition of thread work .start() is not going
            //to run again , that will give exception
            Console.Read();
        }
        public static void Divid()
        { 
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void Add()
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                j = j + i;
                Console.WriteLine(j);
            }
        }
    }
}
