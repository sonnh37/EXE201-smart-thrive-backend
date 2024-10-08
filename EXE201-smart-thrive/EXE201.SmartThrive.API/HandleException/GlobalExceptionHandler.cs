﻿using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Models.Responses;
using Microsoft.AspNetCore.Diagnostics;

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

            httpContext.Response.StatusCode = response.Status;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
