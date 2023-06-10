using System.Text;
using System.Text.Json;

namespace Mvs.Application.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception, _logger);
        }
    }


    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
    {
        var builder = new StringBuilder();

        var message = exception.Message;
        var errorGuid = Guid.NewGuid();

        builder.AppendLine($"Error Guid: {errorGuid}");
        builder.AppendLine($"Date: {DateTime.Now}");
        builder.AppendLine($"Message: {message}");

        logger.LogError(exception, builder.ToString());

        context.Response.Clear();
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var result = JsonSerializer.Serialize(new
        {
            status = StatusCodes.Status500InternalServerError,
            guid = errorGuid,
            detail = message,
        });
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}