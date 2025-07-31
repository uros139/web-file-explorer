using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebFileExplorer.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Folders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Folders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Folders_Folders_ParentId",
                    column: x => x.ParentId,
                    principalTable: "Folders",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Files",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                FolderId = table.Column<Guid>(type: "uuid", nullable: false),
                SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                MimeType = table.Column<string>(type: "text", nullable: false),
                StoragePath = table.Column<string>(type: "text", nullable: false),
                FileContent = table.Column<byte[]>(type: "bytea", nullable: true),
                ThumbnailData = table.Column<byte[]>(type: "bytea", nullable: true),
                TextContent = table.Column<string>(type: "text", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Files", x => x.Id);
                table.ForeignKey(
                    name: "FK_Files_Folders_FolderId",
                    column: x => x.FolderId,
                    principalTable: "Folders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Files_FolderId",
            table: "Files",
            column: "FolderId");

        migrationBuilder.CreateIndex(
            name: "IX_Folders_ParentId",
            table: "Folders",
            column: "ParentId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Files");

        migrationBuilder.DropTable(
            name: "Folders");
    }
}
