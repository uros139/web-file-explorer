using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.Delete;

public record DeleteFolderCommand(Guid Id) : IRequest<Result>;
