using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.HandleException
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = exception switch
            {
                ApiException apiEx => new ProblemDetails
                {
                    Status = apiEx.StatusCode,
                    Type = apiEx.GetType().Name,
                    Title = apiEx.Message,
                    Detail = apiEx.ExceptionMessage,
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                },
                _ => new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = exception.GetType().Name,
                    Title = "Internal server error",
                    Detail = "Internal server error",
                    Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                }

            };
            await httpContext.Response.WriteAsJsonAsync(response);
            return true;
        }
    }
}
