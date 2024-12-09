using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace Library.API.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while process.",
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
        };
        var json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsync(json, cancellationToken);

        return true;
    }
}
