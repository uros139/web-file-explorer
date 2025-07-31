namespace WebFileExplorer.Api.Infrastructure.ExceptionHandling;

public interface IExceptionHandlerStrategy
{
    bool CanHandle(Exception exception);
    ValueTask HandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken);
}
