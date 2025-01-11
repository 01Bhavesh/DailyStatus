using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Id = 1;
            p.Name = "Vinay";
            p.Field = "Teacher";


            BinaryFormatter formatter = new BinaryFormatter(); // Serialization data into byte code
            using (FileStream fs = new FileStream(@"C:\\Users\\Nimap\\source\\repos\\DailyStatus\\Person.txt", FileMode.Create))
            {
                formatter.Serialize(fs, p);
            }

            using (FileStream fs = new FileStream(@"C:\\Users\\Nimap\\source\\repos\\DailyStatus\\Person.txt", FileMode.Open))
            {
                Person desializationObj = (Person)formatter.Deserialize(fs); // Deserialization
                Console.WriteLine(desializationObj.Name + " " + desializationObj.Field);
            }
        }
    }
}
