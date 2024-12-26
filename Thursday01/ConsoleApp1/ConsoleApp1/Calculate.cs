using System;

namespace ConsoleApp1
{
    public class Calculate
    {
        public int num1;
        public int num2;
        Random random = new Random();
        public void Divide()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (this)
                {
                    num1 = random.Next(1, 5);
                    num2 = random.Next(1, 5);
                    Console.WriteLine(num1 +"  " + num2);
                    int val = (num1 / num2);
                    num1 = 0;
                    num2 = 0;
                }
            }
        }
    }
}