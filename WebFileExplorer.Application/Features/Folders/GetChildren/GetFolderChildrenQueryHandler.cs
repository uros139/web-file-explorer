using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetChildren;

internal sealed class GetFolderChildrenQueryHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<GetFolderChildrenQuery, Result<List<FolderResponse>>>
{
    public async Task<Result<List<FolderResponse>>> Handle(GetFolderChildrenQuery request, CancellationToken cancellationToken)
    {
        var children = await folderRepository
            .QueryAll()
            .Where(f => f.ParentId == request.ParentId)
            .ToListAsync(cancellationToken);

        return Result<List<FolderResponse>>.Success(mapper.Map<List<FolderResponse>>(children));
    }
}
