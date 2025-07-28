using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Get
{
    internal sealed class GetFilesQueryHandler(
        IRepository<File> fileRepository,
        IMapper mapper
    ) : IRequestHandler<GetFilesQuery, List<FileResponse>>
    {
        public async Task<List<FileResponse>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
        {
            var files = await fileRepository
                .QueryAllAsNoTracking()
                .ToListAsync(cancellationToken);

            return mapper.Map<List<FileResponse>>(files);
        }
    }

}
