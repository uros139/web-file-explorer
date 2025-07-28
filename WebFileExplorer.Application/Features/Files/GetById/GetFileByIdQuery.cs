using MediatR;

namespace WebFileExplorer.Application.Features.Files.GetById;

public record GetFileByIdQuery(Guid Id) : IRequest<FileResponse>;
