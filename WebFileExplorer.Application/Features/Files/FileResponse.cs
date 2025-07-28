namespace WebFileExplorer.Application.Features.Files;

public record FileResponse(
    Guid Id,
    string Name,
    Guid FolderId,
    long SizeInBytes,
    string MimeType,
    DateTime CreatedAt,
    DateTime ModifiedAt
);
