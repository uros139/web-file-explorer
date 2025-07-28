using MediatR;

namespace WebFileExplorer.Application.Features.Files.Delete;
public record DeleteFileCommand(Guid Id) : IRequest;
