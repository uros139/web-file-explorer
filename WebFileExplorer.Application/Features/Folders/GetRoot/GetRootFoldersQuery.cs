using MediatR;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Application.Features.Folders.GetRoot;

public record GetRootFoldersQuery() : IRequest<Result<List<FolderResponse>>>;
