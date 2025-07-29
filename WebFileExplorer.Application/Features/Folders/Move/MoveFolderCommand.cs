using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Move;

public record MoveFolderCommand(
    Guid Id,
    Guid? NewParentId
) : IRequest<Result<FolderResponse>>;
