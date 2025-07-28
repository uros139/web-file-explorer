using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Exceptions;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Update;

internal sealed class UpdateFileCommandHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<UpdateFileCommand, FileResponse>
{
    public async Task<FileResponse> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (file == null)
            throw new NotFoundException($"File with ID {request.Id} not found.");

        file.Update(request.Name, request.TextContent);

        await fileRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<FileResponse>(file);
    }
}