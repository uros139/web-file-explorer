using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Rename;

internal sealed class RenameFolderCommandHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<RenameFolderCommand, Result<FolderResponse>>
{
    public async Task<Result<FolderResponse>> Handle(RenameFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result<FolderResponse>.Failure($"Folder with ID {request.Id} not found.");

        folder.Rename(request.NewName);

        await folderRepository.SaveChangesAsync(cancellationToken);

        return Result<FolderResponse>.Success(mapper.Map<FolderResponse>(folder));
    }
}
