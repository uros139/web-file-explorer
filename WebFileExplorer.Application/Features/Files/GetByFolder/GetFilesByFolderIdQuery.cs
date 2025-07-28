using MediatR;

namespace WebFileExplorer.Application.Features.Files.GetByFolder;

public record GetFilesByFolderIdQuery(Guid FolderId) : IRequest<List<FileResponse>>;
