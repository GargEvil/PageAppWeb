using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace PageApp.Infrastracture.ExceptionHandling;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            var message = exception.Message;
            var stackTrace = exception.StackTrace;
            var date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            _logger.LogError("{date} - Unhandled Exception: {message} - StackTrace: {stackTrace}  ", date, message, stackTrace);
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var error = JsonConvert.SerializeObject(new ApiError(HttpStatusCode.InternalServerError, exception.Message));
        await context.Response.WriteAsync(error);
    }
}