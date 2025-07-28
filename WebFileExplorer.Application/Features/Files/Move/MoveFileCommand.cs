using MediatR;

namespace WebFileExplorer.Application.Features.Files.Move;

public record MoveFileCommand(
    Guid Id,
    Guid NewFolderId
) : IRequest<FileResponse>;
