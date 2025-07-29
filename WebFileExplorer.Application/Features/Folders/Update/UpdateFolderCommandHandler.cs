using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Update;

internal sealed class UpdateFolderCommandHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<UpdateFolderCommand, Result<FolderResponse>>
{
    public async Task<Result<FolderResponse>> Handle(UpdateFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result<FolderResponse>.Failure($"Folder with ID {request.Id} not found.");

        folder.Update(request.Name);

        await folderRepository.SaveChangesAsync(cancellationToken);

        return Result<FolderResponse>.Success(mapper.Map<FolderResponse>(folder));
    }
}
