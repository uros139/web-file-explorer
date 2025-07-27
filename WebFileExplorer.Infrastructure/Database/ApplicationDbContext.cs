using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Infrastructure.Database;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext{
    public DbSet<File> Files { get; set; }
    public DbSet<Folder> Folders { get; set; }
}