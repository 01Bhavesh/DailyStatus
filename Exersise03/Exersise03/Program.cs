using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exersise03
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PhotoLikes();             Q1

            Console.WriteLine("Enter the name: ");      //Q2
            string name = Console.ReadLine();
            string result = ReverseName(name);
            Console.WriteLine(result);

            //SortEnterNumber();                          //Q3

            //UniqueNumber();                               //Q4

        }
        public static void PhotoLikes()
        {
            string str = "";
            List<string> lt = new List<string>();
            do
            {
                Console.WriteLine("enter name: ");

                str = Console.ReadLine();

                lt.Add(str);

                if (lt.Count == 1)
                {
                    Console.WriteLine($" {lt[0]} like your post "); 
                }
                else if(lt.Count == 2) 
                {
                    Console.WriteLine($" {lt[0]} and {lt[1]} like your post ");
                }
                else 
                { 
                    Console.WriteLine($"{lt[0]} , {lt[1]} and {lt.Count - 2} others like your post");
                }
                
            }while (!string.IsNullOrWhiteSpace(str));
        }
        public static string ReverseName(string name)
        {
            string result = "";
            char[] chars = new char[name.Length];
            for (int i = name.Length - 1; i >= 0; i--)
            {
                chars[name.Length - 1 - i] = name[i];
            }
            result = new string(chars);
            return result;
        }

        public static void SortEnterNumber()
        {
            var arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter number: ");
                int num = int.Parse(Console.ReadLine());
                if (arr.Contains(num))
                {
                    Console.WriteLine("Retry");
                    i--;
                }
                else
                {
                    arr[i] = num;
                }
            }
            Array.Sort(arr);
            Console.WriteLine("sorted array");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

        }

        public static void UniqueNumber()
        {
            List<int> lst = new List<int>();
            Console.WriteLine("enter number: ");
            string num = Console.ReadLine();
            while (num != "Quit")
            {
                lst.Add((int.Parse(num)));
                Console.WriteLine("enter number: ");
                num = Console.ReadLine();
            }
            lst.Sort();
            Console.WriteLine(lst[0]);
            for (int i = 1; i < lst.Count; i++)
            {
                if (lst[i] == lst[i - 1])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(lst[i]);
                }
            }
        }
    }
        
    
}
