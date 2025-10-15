using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace ConnectLegal.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "An unhandled exception occurred: {Message}", exception.Message);

        var problemDetails = new
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Title = "An internal server error occurred.",
            Detail = "Something went wrong. Please try again later.",
            TraceId = httpContext.TraceIdentifier
        };

        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
