using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReviewRevision
{
    //Serialization and Deserialization in C#.NET(With Practical Examples)
    public class Program 
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Id = 1;
            p.Name = "Vinay";
            p.Field = "Teacher";
            string JsonString = JsonSerializer.Serialize(p); // serialization into json
            //int[] arr = { 12, 3, 4, 5 };
            //string jsonint = JsonSerializer.Serialize(arr);
            Console.WriteLine(JsonString);

            Person desrialization = JsonSerializer.Deserialize<Person>(JsonString);//Deserialization into object
            Console.WriteLine(desrialization.Name+" "+desrialization.Field);


            //BinaryFormatter formatter = new BinaryFormatter(); // Serialization data into byte code
            //using (FileStream fs = new FileStream("Person.txt", FileMode.Create))
            //{
            //    formatter.Serialize(fs, p);
            //}

            //using (FileStream fs = new FileStream("Person.txt", FileMode.Open))
            //{
            //    Person desializationObj = (Person)formatter.Deserialize(fs); // Deserialization
            //    Console.WriteLine(desializationObj.Name + " " + desializationObj.Field);
            //}

            //object obj = new { Id = 1, Name = "Bhavesh" }; // Anonymouse Type
            //var obj1 = new { Id = 2, Name = "Vinay" };
            //Console.WriteLine(obj1.Id);
            //Console.WriteLine(obj.ToString());
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine(Array.IndexOf(arr, 4));
            //Array.Sort(arr);
            //Array.Reverse(arr);
            //Array.Resize(ref arr , 10);
            


        }
    }
}
