using System;
using System.Collections.Generic;

namespace ExceptionProgram
{
    public class Divisible
    {
        public void divided(int i, int j)
        {
            try
            {
                if (i / j == 1)
                {
                    Console.WriteLine($"{i} is dividing {j}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"we cannot divide {i} by {j}");
            }
            finally {
                Console.WriteLine("exit");
            }
            
        }

        public List<Person> GetPerson()
        {
            try 
            {
                throw new Exception("Inner Exception");
                //return new List<Person>();
            }
            catch (Exception ex)
            {
                throw new ExceptionClass("Custom exception", ex);
            }
            finally 
            {
                Console.WriteLine("finally block"); 
            }
        }
    }
}