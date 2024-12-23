using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string str = "()()([)[])";// 1st bracket false
            //string str = "()())"; // 2nd bracket false
            //string str = "()()(";   //3rd bracket false
            string str = "(){[()]}";
            bool status = checkParenthesis(str);
            if (status)
            {
                Console.WriteLine("correct");
            }
            else {
                Console.WriteLine("not correct");        
            }
        }
        public static bool checkParenthesis(string str)
        {
            Stack<char> st = new Stack<char>();
            foreach (char c in str)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    st.Push(c);
                }
                else
                {
                    if (st.Any())
                    {
                        char ch = st.Pop();
                        if (ch != '(' && c == ')' || ch != '[' && c == ']' || ch != '{' && c == '}')
                        {
                            Console.WriteLine("1");
                            return false;
                        }
                    }
                    else {
                        Console.WriteLine("2");
                        return false;
                    }
                }
            }
            if (!st.Any())
            {
                return true;
            }
            else {
                Console.WriteLine("3");
                return false; }
            
        }
    }
}
