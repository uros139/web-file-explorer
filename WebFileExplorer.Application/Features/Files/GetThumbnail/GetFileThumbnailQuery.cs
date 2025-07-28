using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Files.GetThumbnail;

public record GetFileThumbnailQuery(Guid Id) : IRequest<Result<ThumbnailResponse>>;
