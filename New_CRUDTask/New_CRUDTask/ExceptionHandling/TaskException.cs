using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Expressions;

namespace New_CRUDTask.ExceptionHandling
{
    public class TaskException : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
                var response = new ErroeException()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ExceptionMessage = exception.Message,
                    Title = "Something went wrong",
                    Details = exception.InnerException.Message
                };

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return true;
        }
    }
}
