using WebFileExplorer.SharedKernel;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Domain.Folders;

public class Folder : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }
    public Folder? Parent { get; set; }
    public ICollection<Folder> Subfolders { get; set; } = new List<Folder>();
    public ICollection<File> Files { get; set; } = new List<File>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    public void Update(string name)
    {
        Name = name;
        ModifiedAt = DateTime.UtcNow;
    }

    public void Rename(string newName)
    {
        Name = newName;
        ModifiedAt = DateTime.UtcNow;
    }

    public void Move(Guid? newParentId)
    {
        ParentId = newParentId;
        ModifiedAt = DateTime.UtcNow;
    }
}