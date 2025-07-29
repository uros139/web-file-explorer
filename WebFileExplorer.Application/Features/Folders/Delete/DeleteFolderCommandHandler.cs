using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Delete;

internal sealed class DeleteFolderCommandHandler(
    IRepository<Folder> folderRepository
) : IRequestHandler<DeleteFolderCommand, Result>
{
    public async Task<Result> Handle(DeleteFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result.Failure($"Folder with ID {request.Id} not found.");

        folderRepository.Remove(folder);
        await folderRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
