namespace WebFileExplorer.Application.Features.Files;

public record ThumbnailResponse(
    byte[] Data,
    string ContentType
);
