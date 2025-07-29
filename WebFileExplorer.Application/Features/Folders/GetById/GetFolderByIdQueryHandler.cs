using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetById;

internal sealed class GetFolderByIdQueryHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<GetFolderByIdQuery, Result<FolderResponse>>
{
    public async Task<Result<FolderResponse>> Handle(GetFolderByIdQuery request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result<FolderResponse>.Failure($"Folder with ID {request.Id} not found.");

        return Result<FolderResponse>.Success(mapper.Map<FolderResponse>(folder));
    }
}
