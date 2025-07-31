using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Domain.Folders;

namespace WebFileExplorer.Infrastructure.Database.Seeding;

internal static class FolderSeed
{
    private static readonly List<Folder> Folders =
    [
        new Folder
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Root",
            ParentId = null,
        },
        new Folder
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Documents",
            ParentId = Guid.Parse("11111111-1111-1111-1111-111111111111")

        },
        new Folder
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Images",
            ParentId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        }
    ];

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>().HasData(Folders);
    }
}
