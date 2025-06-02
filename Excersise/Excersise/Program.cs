using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Excersise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number for checking if number is between 1 to 10");
            int number = int.Parse(Console.ReadLine());
            CheckNumber(number);


            Console.WriteLine("enter 2 numbers for find maximum number");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Maximum number is {0}", FindMaxNumber(num1,num2));

           
            Console.WriteLine("Enter height of an Image");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter width of an Image");
            int width = int.Parse(Console.ReadLine());
            if (height > 0 && width > 0)
            {
                ImageType(height, width);
            }
            else { Console.WriteLine("Enter valid number"); }


        }
        public static void CheckNumber(int number)
        {
            if (number > 1 && number < 10)
            {
                Console.WriteLine("Valid");
            }
            else { Console.WriteLine("Invalid"); }
        }
        public static int FindMaxNumber(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }
        public static void ImageType(int height, int width)
        {
            if (height < width)
            {
                Console.WriteLine("Image is Landscape");
            }
            else { Console.WriteLine("Image is portrait"); }
        }
    }
}
