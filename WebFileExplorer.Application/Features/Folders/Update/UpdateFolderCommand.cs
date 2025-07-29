using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Update;

public record UpdateFolderCommand(
    Guid Id,
    string Name
) : IRequest<Result<FolderResponse>>;
