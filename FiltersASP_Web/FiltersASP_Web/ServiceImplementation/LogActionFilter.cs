using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersASP_Web.ServiceImplementation
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{context.ActionDescriptor.DisplayName} is starting");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{context.ActionDescriptor.DisplayName} is finished");
        }
    }
}
