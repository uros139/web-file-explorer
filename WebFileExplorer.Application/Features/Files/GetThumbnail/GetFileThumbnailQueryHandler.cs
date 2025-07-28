using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel;
using WebFileExplorer.SharedKernel.Api;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.GetThumbnail;

internal sealed class GetFileThumbnailQueryHandler(
    IRepository<File> fileRepository
) : IRequestHandler<GetFileThumbnailQuery, Result<ThumbnailResponse>>
{
    public async Task<Result<ThumbnailResponse>> Handle(GetFileThumbnailQuery request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (file == null)
            return Result<ThumbnailResponse>.Failure($"File with ID {request.Id} not found.");

        if (file.ThumbnailData == null)
            return Result<ThumbnailResponse>.Failure("Thumbnail not available for this file.");

        return Result<ThumbnailResponse>.Success(new ThumbnailResponse(file.ThumbnailData, file.MimeType));
    }
}