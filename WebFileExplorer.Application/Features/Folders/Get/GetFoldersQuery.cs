using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Get;

public record GetFoldersQuery(
    Guid? ParentId = null,
    string? SearchTerm = null
) : IRequest<Result<List<FolderResponse>>>;
