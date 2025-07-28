using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Exceptions;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Move;

internal sealed class MoveFileCommandHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<MoveFileCommand, FileResponse>
{
    public async Task<FileResponse> Handle(MoveFileCommand request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (file == null)
            throw new NotFoundException($"File with ID {request.Id} not found.");

        file.Move(request.NewFolderId);

        await fileRepository.SaveChangesAsync(cancellationToken);
        return mapper.Map<FileResponse>(file);
    }
}