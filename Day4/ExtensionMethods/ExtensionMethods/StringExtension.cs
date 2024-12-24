using System;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static string Shorten(this string str, int NumberOfWord)
        {
            if (str.Length < NumberOfWord)
            {
                throw new ArgumentOutOfRangeException("String lenght is less than numbers required:");
            }
            if (str == null)
            {
                throw new NullReferenceException("string is null");
            }
            string word = string.Join(" ", str.Split(' ').Take(NumberOfWord));
            return word;
        }
    }
}