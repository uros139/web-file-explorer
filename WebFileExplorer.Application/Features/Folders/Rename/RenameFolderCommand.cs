using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Rename;

public record RenameFolderCommand(
    Guid Id,
    string NewName
) : IRequest<Result<FolderResponse>>;
