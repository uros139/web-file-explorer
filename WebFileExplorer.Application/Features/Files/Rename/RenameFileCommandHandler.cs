using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Exceptions;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Rename;

internal sealed class RenameFileCommandHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<RenameFileCommand, FileResponse>
{
    public async Task<FileResponse> Handle(RenameFileCommand request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (file == null)
            throw new NotFoundException($"File with ID {request.Id} not found.");

        file.Name = request.NewName;

        await fileRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<FileResponse>(file);
    }
}
