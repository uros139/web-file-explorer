using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Create;

public record CreateFolderCommand(string Name, Guid? ParentId = null) : IRequest<Result<FolderResponse>>;
