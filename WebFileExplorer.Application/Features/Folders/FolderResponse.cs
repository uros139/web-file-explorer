namespace WebFileExplorer.Application.Features.Folders;

public record FolderResponse(
    Guid Id,
    string Name,
    Guid? ParentId,
    DateTime CreatedAt,
    DateTime ModifiedAt
);
