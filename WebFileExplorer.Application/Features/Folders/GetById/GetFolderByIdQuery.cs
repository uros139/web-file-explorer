using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetById;

public record GetFolderByIdQuery(Guid Id) : IRequest<Result<FolderResponse>>;
