namespace WebFileExplorer.Application.Features.Files;

public record FileContentResponse(
    byte[]? Data,
    string ContentType,
    string FileName
);
