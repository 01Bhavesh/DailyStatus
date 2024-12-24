using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsType
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(1,"Rohit","Sharma");
            var p1 = new GenericList<Person>();
            p1.Add(p);
            Console.WriteLine(" "+p1.pop(0));
            

            //var p2 = new GenericList<int>(); // beacuse genericeList as restricted to use only classes

            var p3 = new GenericList<String>();
            p3.Add("Virat");
        }
    }
    public class GenericList<T> where T : class
    {
        List<T> lst = new List<T>();
        public void Add(T value)
        {
            lst.Add(value);
        }
        public T pop(int index)
        {
            var p = lst[index];
            return p;
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }            
        }
    }
}
