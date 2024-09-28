using EXE201.SmartThrive.Domain.Models.Responses;
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
                ApiException apiEx => new BusinessResult
                {
                    Status = apiEx.StatusCode,
                    Message = apiEx.Message,
                    Data = exception.Message,
                },
                _ => new BusinessResult
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Internal Error",
                    Data = exception.Message,
                }

            };
            await httpContext.Response.WriteAsJsonAsync(response);
            return true;
        }
    }
}
