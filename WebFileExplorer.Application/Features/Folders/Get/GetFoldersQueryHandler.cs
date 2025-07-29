using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Get;

internal sealed class GetFoldersQueryHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<GetFoldersQuery, Result<List<FolderResponse>>>
{
    public async Task<Result<List<FolderResponse>>> Handle(GetFoldersQuery request, CancellationToken cancellationToken)
    {
        var query = folderRepository.QueryAll();

        if (request.ParentId.HasValue)
        {
            query = query.Where(f => f.ParentId == request.ParentId);
        }

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(f => f.Name.Contains(request.SearchTerm));
        }

        var folders = await query.ToListAsync(cancellationToken);

        return Result<List<FolderResponse>>.Success(mapper.Map<List<FolderResponse>>(folders));
    }
}
