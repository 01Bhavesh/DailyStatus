using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberWords = CheckingWords("C:\\Users\\Nimap\\source\\repos\\DailyStatus\\FileHandling\\FileHandling\\Data.txt");          //Q1
            Console.WriteLine("Numbers of words in file are : "+numberWords);

            string word = LongestWord("C:\\Users\\Nimap\\source\\repos\\DailyStatus\\FileHandling\\FileHandling\\Data.txt");
            Console.WriteLine("Longest Word in file is : "+word);
        }
        public static int CheckingWords(string path)
        {
            var str = (System.IO.File.ReadAllText(path)).Split(' ');
            return str.Length;
        }
        public static string LongestWord(string path)
        {
            var str = File.ReadAllText(path).Split(' ');
            int count = 0;
            string word = ""; 

            for (int i = 0; i < str.Length; i++)
            {
                if (count < str[i].Length)
                {
                    count = str[i].Length;
                    word = str[i];
                }
            }
            return word;
        }
    }
}
