using Azure;
using System.Net;
using System.Text.Json;

namespace Estudos.BlobStorage.Settings;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            string? message = null;
            switch (error)
            {
                case RequestFailedException e:
                    // Azure error
                    response.StatusCode = e.Status;
                    message = e.Message.Split(".")[0];
                    break;

                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(
                new
                {
                    success = false,
                    message = message ?? error?.Message
                });
            await response.WriteAsync(result);
        }
    }
}