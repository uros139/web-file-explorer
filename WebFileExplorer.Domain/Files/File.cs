using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel;

namespace WebFileExplorer.Domain.Files;

public class File : Entity
{
    public string Name { get; set; } = String.Empty;

    public int FolderId { get; set; }
    public Folder Folder { get; set; } = null!;

    public long SizeInBytes { get; set; }
    public string? MimeType { get; set; }
}