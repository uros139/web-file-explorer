using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Exceptions;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.GetById;

internal sealed class GetFileByIdQueryHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<GetFileByIdQuery, FileResponse>
{
    public async Task<FileResponse> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
           .Where(x => x.Id == request.Id)
           .SingleOrDefaultAsync(cancellationToken);
        
        if (file == null)
            throw new NotFoundException($"File with ID {request.Id} not found.");
        
        return mapper.Map<FileResponse>(file);
    }
}
