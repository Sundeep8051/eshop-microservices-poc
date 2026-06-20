using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Common.Handlers
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception != null)
            {
                var ex = new
                {
                    Message = exception.Message + " " + ",From handler",
                    exception.GetType().Name,

                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync($"Some exception occured, details: {ex}");
            }
            return true;
        }
    }

}
