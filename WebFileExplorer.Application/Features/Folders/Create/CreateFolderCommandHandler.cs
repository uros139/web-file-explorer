using AutoMapper;
using MediatR;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Create;

internal sealed class CreateFolderCommandHandler(
    IRepository<Folder> folderRepository,
    IMapper mapper
) : IRequestHandler<CreateFolderCommand, Result<FolderResponse>>
{
    public async Task<Result<FolderResponse>> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = new Folder
        {
            Name = request.Name,
            ParentId = request.ParentId
        };

        await folderRepository.AddAsync(folder, cancellationToken);
        await folderRepository.SaveChangesAsync(cancellationToken);

        return Result<FolderResponse>.Success(mapper.Map<FolderResponse>(folder));
    }
}
