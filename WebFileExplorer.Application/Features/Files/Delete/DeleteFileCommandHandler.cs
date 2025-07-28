using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Application.Features.Files.Delete;
using File = WebFileExplorer.Domain.Files.File;

internal sealed class DeleteFileCommandHandler(
    IRepository<File> fileRepository
) : IRequestHandler<DeleteFileCommand>
{
    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (file != null)
        {
            fileRepository.Remove(file);
            await fileRepository.SaveChangesAsync(cancellationToken);
        }
    }
}