using MediatR;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Api;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.GetContent;

internal sealed class GetFileContentQueryHandler(
    IRepository<File> fileRepository
) : IRequestHandler<GetFileContentQuery, Result<FileContentResponse>>
{
    public async Task<Result<FileContentResponse>> Handle(GetFileContentQuery request, CancellationToken cancellationToken)
    {
        var file = await fileRepository
            .QueryAll()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (file == null)
            return Result<FileContentResponse>.Failure($"File with ID {request.Id} not found.");

        if (file.FileContent == null)
            return Result<FileContentResponse>.Failure("File content not available.");

        return Result<FileContentResponse>.Success(new FileContentResponse(file.FileContent, file.MimeType, file.Name));
    }
}