using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Files.GetContent;

public record GetFileContentQuery(Guid Id) : IRequest<Result<FileContentResponse>>;
