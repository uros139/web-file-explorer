using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Exceptions;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.GetByFolder;

internal sealed class GetFilesByFolderIdQueryHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<GetFilesByFolderIdQuery, List<FileResponse>>
{
    public async Task<List<FileResponse>> Handle(GetFilesByFolderIdQuery request, CancellationToken cancellationToken)
    {
        var files = await fileRepository
            .QueryAll()
           .Where(x => x.FolderId == request.FolderId)
           .ToListAsync(cancellationToken);

        return mapper.Map<List<FileResponse>>(files);
    }
}
