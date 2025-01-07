using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_await_application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var val = add().Result;  // return value and we haven't used await
            var val = add();  //not returning any value
            Console.WriteLine(val);

            //List<string> lst = new List<string>() { "bhavesh", "sakharam", "gharat" };
            //List<int> lst = new List<int>() { 1, 2, 3, 4, 5 };
            Person p = new Person();
            List<Person> lst = new List<Person>() {
            new Person{Id = 1 , Name = "Bhavesh"},
            new Person{ Id = 2 , Name = "Vinay"}
            };
            foreach (var item in lst)
            {
                Console.WriteLine(item.Name);
            }

            var value = Plus<int>(12);  // passing int data 
            Console.WriteLine(value);
            string str = Plus<string>("bhavesh"); // passing string data
            Console.WriteLine(str);


        }
        public static async Task<int> add()
        {
            return 5;
        }

        public static T Plus<T>(T id) // Use Generic
        {
            return id;
        }
    }
}
