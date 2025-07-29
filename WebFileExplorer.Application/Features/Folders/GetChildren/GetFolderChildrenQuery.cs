using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetChildren;

public record GetFolderChildrenQuery(Guid ParentId) : IRequest<Result<List<FolderResponse>>>;
