using System;

namespace Ienumerable_Ienumerator
{
    public class Person
    {
        public int Id;
        public string Name;
        public Person(int id = 0 , string name = null)
        {
            Id = id;
            Name = name;

        }
        public static void swap()
        {
            Console.WriteLine("swap numbers");
        }
        public void add()
        {
            swap();            // non static method can access static methods
            Console.WriteLine("addition");
        }

    }
}
