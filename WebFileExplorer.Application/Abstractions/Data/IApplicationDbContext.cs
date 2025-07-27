using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Domain.Folders;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<File> Files { get; }
    DbSet<Folder> Folders { get; }
}