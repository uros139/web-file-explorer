using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetTree;

public record GetFolderTreeQuery(
    Guid? ParentId = null,
    int MaxDepth = 3
) : IRequest<Result<List<FolderTreeResponse>>>;
