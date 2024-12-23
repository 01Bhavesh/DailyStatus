using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
    
            CheckDifferntMethod();   
        }
        public static void CheckDifferntMethod()
        {
            Person p1 = new Person(1, "Bhavesh", "Gharat");
            Person p2 = new Person(2, "Vinay", "Indulkar");
            Person p3 = new Person(3, "Jitesh", "sharma");
            Person p4 = new Person(4, "Sarvesh", "Rathod");

            List<Person> lst = new List<Person>();
            lst.Add(p1);
            lst.Add(p2);
            lst.Add(p3);
            lst.Add(p4);
           

            //Console.WriteLine(p4.ToString());
            foreach (Person p in lst)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
           
            lst.Remove(p3);
            foreach (Person p in lst)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            lst.Insert(1, p3);
            foreach (Person p in lst)
            {
                Console.WriteLine(p);
            }
            


        }
    }
}
