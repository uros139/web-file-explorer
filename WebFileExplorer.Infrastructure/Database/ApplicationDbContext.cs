using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;
using WebFileExplorer.Infrastructure.Database.Seeding;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Infrastructure.Database;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<File> Files { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        FolderSeed.Seed(modelBuilder);
        FilesSeed.Seed(modelBuilder);
    }
}