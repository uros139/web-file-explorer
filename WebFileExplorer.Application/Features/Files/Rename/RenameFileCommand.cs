using MediatR;

namespace WebFileExplorer.Application.Features.Files.Rename;

public record RenameFileCommand(
    Guid Id,
    string NewName
) : IRequest<FileResponse>;
