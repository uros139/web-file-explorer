using MediatR;

namespace WebFileExplorer.Application.Features.Files.Update;

public record UpdateFileCommand(
    Guid Id,
    string Name,
    string? TextContent
) : IRequest<FileResponse>;
