using MediatR;

namespace WebFileExplorer.Application.Features.Files.Get;

public record GetFilesQuery(
    Guid? FolderId = null,
    string? SearchTerm = null
) : IRequest<List<FileResponse>>;
