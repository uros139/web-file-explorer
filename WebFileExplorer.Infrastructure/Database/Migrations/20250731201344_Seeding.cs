using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebFileExplorer.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Seeding : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Folders",
            columns: new[] { "Id", "Name", "ParentId" },
            values: new object[,]
            {
                { new Guid("11111111-1111-1111-1111-111111111111"), "Root", null },
                { new Guid("22222222-2222-2222-2222-222222222222"), "Documents", new Guid("11111111-1111-1111-1111-111111111111") },
                { new Guid("33333333-3333-3333-3333-333333333333"), "Images", new Guid("11111111-1111-1111-1111-111111111111") }
            });

        migrationBuilder.InsertData(
            table: "Files",
            columns: new[] { "Id", "FileContent", "FolderId", "MimeType", "Name", "SizeInBytes", "TextContent", "ThumbnailData" },
            values: new object[,]
            {
                { new Guid("11111111-1111-1111-1111-111111111111"), new byte[] { 84, 104, 105, 115, 32, 105, 115, 32, 97, 32, 115, 97, 109, 112, 108, 101, 32, 116, 101, 120, 116, 32, 102, 105, 108, 101, 46 }, new Guid("22222222-2222-2222-2222-222222222222"), "text/plain", "Readme.txt", 27L, "This is a sample text file.", null },
                { new Guid("22222222-2222-2222-2222-222222222222"), new byte[] { 83, 111, 109, 101, 32, 105, 109, 112, 111, 114, 116, 97, 110, 116, 32, 110, 111, 116, 101, 115, 32, 104, 101, 114, 101, 46 }, new Guid("22222222-2222-2222-2222-222222222222"), "text/plain", "Notes.txt", 22L, "Some important notes here.", null },
                { new Guid("33333333-3333-3333-3333-333333333333"), new byte[] { 255, 216, 255 }, new Guid("33333333-3333-3333-3333-333333333333"), "image/jpeg", "Sample.jpg", 1024L, null, new byte[] { 0, 1, 2 } }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Files",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

        migrationBuilder.DeleteData(
            table: "Files",
            keyColumn: "Id",
            keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

        migrationBuilder.DeleteData(
            table: "Files",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

        migrationBuilder.DeleteData(
            table: "Folders",
            keyColumn: "Id",
            keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

        migrationBuilder.DeleteData(
            table: "Folders",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

        migrationBuilder.DeleteData(
            table: "Folders",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
    }
}
