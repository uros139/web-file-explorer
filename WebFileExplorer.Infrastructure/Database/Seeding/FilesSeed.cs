using Microsoft.EntityFrameworkCore;
using System.Text;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Infrastructure.Database.Seeding;

internal static class FilesSeed
{
    private static readonly List<File> Files =
    [
        new File
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Readme.txt",
            FolderId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // Documents
            MimeType = "text/plain",
            SizeInBytes = 27,
            FileContent = Encoding.UTF8.GetBytes("This is a sample text file."),
            TextContent = "This is a sample text file."
        },
        new File
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Notes.txt",
            FolderId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // Documents
            MimeType = "text/plain",
            SizeInBytes = 22,
            FileContent = Encoding.UTF8.GetBytes("Some important notes here."),
            TextContent = "Some important notes here."
        },
        new File
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Sample.jpg",
            FolderId = Guid.Parse("33333333-3333-3333-3333-333333333333"), // Images
            MimeType = "image/jpeg",
            SizeInBytes = 1024,
            FileContent = [0xFF, 0xD8, 0xFF], // JPEG SOI marker (mock)
            ThumbnailData = [0x00, 0x01, 0x02] // Mock preview
        }
    ];

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>().HasData(Files);
    }
}
