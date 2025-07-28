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
    public string StoragePath { get; set; } = string.Empty;
    public byte[]? FileContent { get; set; }
    public byte[]? ThumbnailData { get; set; }
    public string? TextContent { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    public void Update(string name, string? textContent = null)
    {
        Name = name;
        if (textContent != null)
        {
            TextContent = textContent;
        }
        ModifiedAt = DateTime.UtcNow;
    }

    public void Move(Guid newFolderId)
    {
        FolderId = newFolderId;
        ModifiedAt = DateTime.UtcNow;
    }
}