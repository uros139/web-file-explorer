using MediatR;
using Microsoft.AspNetCore.Http;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Files.Upload;

public record UploadFileCommand(
    Guid FolderId,
    IFormFile File
) : IRequest<Result<FileResponse>>;