using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetPath;

internal sealed class GetFolderPathQueryHandler(
  IRepository<Folder> folderRepository
) : IRequestHandler<GetFolderPathQuery, Result<FolderPathResponse>>
{
    public async Task<Result<FolderPathResponse>> Handle(GetFolderPathQuery request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result<FolderPathResponse>.Failure($"Folder with ID {request.Id} not found.");

        var pathSegments = new List<FolderPathSegment>();
        var currentFolder = folder;

        while (currentFolder != null)
        {
            pathSegments.Insert(0, new FolderPathSegment(currentFolder.Id, currentFolder.Name));

            if (currentFolder.ParentId.HasValue)
            {
                currentFolder = await folderRepository
                    .QueryAll()
                    .Where(x => x.Id == currentFolder.ParentId.Value)
                    .SingleOrDefaultAsync(cancellationToken);
            }
            else
            {
                currentFolder = null;
            }
        }

        return Result<FolderPathResponse>.Success(new FolderPathResponse(pathSegments));
    }
}
