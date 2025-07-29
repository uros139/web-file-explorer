using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetPath;

public record GetFolderPathQuery(Guid Id) : IRequest<Result<FolderPathResponse>>;
