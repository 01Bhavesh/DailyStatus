using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ienumerable_Ienumerator
{
    public class Program
    {
         static void Main(string[] args)
        {
            //add();          //static method can access static fields not non-static field
            //swap();
            //Person p = new Person();        
            //p.add();            // for accesing non-static method in main method we need to
                                // create class/object and through that object we can access
                                // non- static method
            List<Person> lst = new List<Person> {
                new Person (2 , "virat"),
                new Person(3,"Hardik"),
                new Person(4,"Rishab"),
                new Person (5 , "Rahul"),
                new Person(6,"Kuldeep"),
                new Person(7,"Jaiswal")
            };
            Person p = new Person(3,"Hardik");
            //Console.WriteLine(lst.Contains(p));
            //Console.WriteLine();

            //foreach (var l in lst)
            //{
            //    l.Name = "bhavesh";
            //}
            //foreach (var l in lst)
            //{
            //    Console.WriteLine(l.Id+" "+l.Name);
            //}
            IEnumerable<Person> ienumer = (IEnumerable<Person>)lst;//Internally use IEnumerator and use
                                                                   //for Iterating collection of object
                                                                   //Ienumerable_1_4(ienumer);

            //Ienumerable_1_4(ienumer);
            //foreach (var l in lst)
            //{
            //    Console.WriteLine(l.Id + " " + l.Name);
            //}
            IEnumerator<Person> ienumerator = lst.GetEnumerator();
            Ienumerator_1_4(ienumerator);


        }

        public static void Ienumerable_1_4(IEnumerable<Person> lst)     
        {
            foreach (Person per in lst)
            {
                //per.Name = "vinay";   // checking
                //Console.WriteLine("hollo");
                if (per.Id > 5)
                {
                    Ienumrable_5_7(lst);
                }
                Console.WriteLine(per.Name);
            }
        }
        public static void Ienumrable_5_7(IEnumerable<Person> lst)
        {
            Console.WriteLine();
            foreach (Person per in lst)
            {
                Console.WriteLine(per.Name);
            }
        }
        
        public static void swap()
        {
            Console.WriteLine("swap numbers");
        }

        public static void Ienumerator_1_4(IEnumerator<Person> lst)
        {
            while (lst.MoveNext())
            {
                Console.WriteLine(lst.Current.Id + " " + lst.Current.Name);
                if (lst.Current.Id >= 5)
                {
                    Ienumerator_5_7(lst);
                }
                
            }
        }

        private static void Ienumerator_5_7(IEnumerator<Person> lst)
        {
            Console.WriteLine();
            while (lst.MoveNext())
            {
                Console.WriteLine(lst.Current.Id + " " + lst.Current.Name);
            }
        }
    }
}
