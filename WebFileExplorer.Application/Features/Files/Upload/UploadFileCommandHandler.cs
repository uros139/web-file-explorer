using AutoMapper;
using MediatR;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.SharedKernel.Api;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Upload;

internal sealed class UploadFileCommandHandler(
    IRepository<File> fileRepository,
    IMapper mapper
) : IRequestHandler<UploadFileCommand, Result<FileResponse>>
{
    public async Task<Result<FileResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
            return Result<FileResponse>.Failure("File is required and cannot be empty.");

        using var stream = request.File.OpenReadStream();
        var fileContent = new byte[request.File.Length];
        await stream.ReadExactlyAsync(fileContent, cancellationToken);

        var file = new File
        {
            Name = request.File.FileName,
            FolderId = request.FolderId,
            SizeInBytes = request.File.Length,
            MimeType = request.File.ContentType,
            FileContent = fileContent
        };

        await fileRepository.AddAsync(file, cancellationToken);
        await fileRepository.SaveChangesAsync(cancellationToken);

        return Result<FileResponse>.Success(mapper.Map<FileResponse>(file));
    }
}