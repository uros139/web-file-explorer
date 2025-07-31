using WebFileExplorer.Domain.Folders;
using WebFileExplorer.SharedKernel;

namespace WebFileExplorer.Domain.Files;

public class File : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid FolderId { get; set; }
    public Folder Folder { get; set; } = null!;
    public long SizeInBytes { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = null!;
    public byte[]? ThumbnailData { get; set; }
    public string? TextContent { get; set; }

    public void Update(string name, string? textContent = null)
    {
        Name = name;
        if (textContent != null)
        {
            TextContent = textContent;
        }
    }

    public void Move(Guid newFolderId)
    {
        FolderId = newFolderId;
    }
}
