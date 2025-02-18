using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Expressions;

namespace New_CRUDTask.ExceptionHandling
{
    public class TaskException : Exception
    {
        public TaskException()
        {
            
        }
        public TaskException(string msg) : base(msg)
        {
            
        }
        public TaskException(string msg,Exception ex) : base(msg,ex)
        {

        }
    }
}
