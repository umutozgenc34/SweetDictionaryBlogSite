using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace SweetDictionaryBlogSite.WebApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ReturnModel<string> Errors = new ReturnModel<string>();
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = 500;

        if (exception.GetType() == typeof(NotFoundException))
        {
            httpContext.Response.StatusCode = 404;
            Errors.Success = false;
            Errors.Message = exception.Message;
            Errors.Status = 404;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors));
        }

        if (exception.GetType() == typeof(BusinessException))
        {
            httpContext.Response.StatusCode = 400;
            Errors.Success = false;
            Errors.Message = exception.Message;
            Errors.Status = 400;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors));
        }

        Errors.Status = 500;
        Errors.Success = false;
        Errors.Message = exception.Message;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors));
        return true;
    }
}
