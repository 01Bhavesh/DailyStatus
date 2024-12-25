using System;

namespace ExceptionProgram
{
    public class ExceptionClass : Exception
    {
        public ExceptionClass(string msg , Exception innerException) : base(msg , innerException)
        {
            
        }
    }
}