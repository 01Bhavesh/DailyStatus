using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLogicalCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "aaachc";
            string str1 = nonrepeating(str);
            Console.WriteLine(str1);

            char firstUnique = firstUniqueChar(str);
            Console.WriteLine("character :- "+ firstUnique);
        }
        public static string nonrepeating(string str)
        {
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str[i] == str1[j])
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    str1 = str1 + str[i];

                }
            }
            return str1;
        }

        public static char firstUniqueChar(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j] && i != j)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("i = " + i );
                    return str[i];
                }
            }
            return ' ';
        }
    }
}
