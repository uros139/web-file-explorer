using WebFileExplorer.SharedKernel;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Domain.Folders;

public class Folder : Entity
{
    public string Name { get; set; } = String.Empty;
    public int? ParentId { get; set; }
    public Folder? Parent { get; set; }

    public ICollection<Folder> Subfolders { get; set; } = new List<Folder>();
    public ICollection<File> Files { get; set; } = new List<File>();
}