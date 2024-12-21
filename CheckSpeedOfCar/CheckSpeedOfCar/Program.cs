using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSpeedOfCar
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter speed limit of car in km/hr: ");
            int speedLimit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Speed of the car in km/hr: ");
            int speedCar = int.Parse(Console.ReadLine());
            var p1 = new CarSpeed(speedLimit, speedCar);
            string result = p1.CheckSpeed();
            Console.WriteLine(result);
        }
    }
}
