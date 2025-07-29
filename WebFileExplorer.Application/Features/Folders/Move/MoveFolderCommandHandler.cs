using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Move;

internal sealed class MoveFolderCommandHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<MoveFolderCommand, Result<FolderResponse>>
{
    public async Task<Result<FolderResponse>> Handle(MoveFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = await folderRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (folder == null)
            return Result<FolderResponse>.Failure($"Folder with ID {request.Id} not found.");

        folder.Move(request.NewParentId);

        await folderRepository.SaveChangesAsync(cancellationToken);

        return Result<FolderResponse>.Success(mapper.Map<FolderResponse>(folder));
    }
}
