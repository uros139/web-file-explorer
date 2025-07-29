namespace WebFileExplorer.Application.Features.Folders;

public record FolderTreeResponse(
    Guid Id,
    string Name,
    Guid? ParentId,
    List<FolderTreeResponse> Children
);
