using Microsoft.AspNetCore.Mvc;
using WebFileExplorer.SharedKernel.Exceptions;

namespace WebFileExplorer.Api.Infrastructure.ExceptionHandling;

public class NotFoundExceptionHandlerStrategy(ILogger<NotFoundExceptionHandlerStrategy> logger) : IExceptionHandlerStrategy
{
    public bool CanHandle(Exception exception) => exception is NotFoundException;

    public async ValueTask HandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        var notFoundException = (NotFoundException)exception;

        logger.LogWarning(exception, "Resource not found");

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            Title = "Resource not found",
            Detail = notFoundException.Message
        };

        context.Response.StatusCode = problemDetails.Status.Value;
        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
    }
}
