using WebFileExplorer.SharedKernel;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Domain.Folders;

public class Folder : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }
    public Folder? Parent { get; set; }

    public ICollection<Folder> Subfolders { get; set; } = [];
    public ICollection<File> Files { get; set; } = [];

    public void Update(string name)
    {
        Name = name;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    public void Move(Guid? newParentId)
    {
        ParentId = newParentId;
    }
}