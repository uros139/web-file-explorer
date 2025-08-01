﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebFileExplorer.Infrastructure.Database;

#nullable disable

namespace WebFileExplorer.Infrastructure.Migrations;

[DbContext(typeof(ApplicationDbContext))]
partial class ApplicationDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.7")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("WebFileExplorer.Domain.Files.File", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<byte[]>("FileContent")
                    .IsRequired()
                    .HasColumnType("bytea");

                b.Property<Guid>("FolderId")
                    .HasColumnType("uuid");

                b.Property<string>("MimeType")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.Property<long>("SizeInBytes")
                    .HasColumnType("bigint");

                b.Property<string>("TextContent")
                    .HasColumnType("text");

                b.Property<byte[]>("ThumbnailData")
                    .HasColumnType("bytea");

                b.HasKey("Id");

                b.HasIndex("FolderId");

                b.ToTable("Files");

                b.HasData(
                    new
                    {
                        Id = new Guid("11111111-1111-1111-1111-111111111111"),
                        FileContent = new byte[] { 84, 104, 105, 115, 32, 105, 115, 32, 97, 32, 115, 97, 109, 112, 108, 101, 32, 116, 101, 120, 116, 32, 102, 105, 108, 101, 46 },
                        FolderId = new Guid("22222222-2222-2222-2222-222222222222"),
                        MimeType = "text/plain",
                        Name = "Readme.txt",
                        SizeInBytes = 27L,
                        TextContent = "This is a sample text file."
                    },
                    new
                    {
                        Id = new Guid("22222222-2222-2222-2222-222222222222"),
                        FileContent = new byte[] { 83, 111, 109, 101, 32, 105, 109, 112, 111, 114, 116, 97, 110, 116, 32, 110, 111, 116, 101, 115, 32, 104, 101, 114, 101, 46 },
                        FolderId = new Guid("22222222-2222-2222-2222-222222222222"),
                        MimeType = "text/plain",
                        Name = "Notes.txt",
                        SizeInBytes = 22L,
                        TextContent = "Some important notes here."
                    },
                    new
                    {
                        Id = new Guid("33333333-3333-3333-3333-333333333333"),
                        FileContent = new byte[] { 255, 216, 255 },
                        FolderId = new Guid("33333333-3333-3333-3333-333333333333"),
                        MimeType = "image/jpeg",
                        Name = "Sample.jpg",
                        SizeInBytes = 1024L,
                        ThumbnailData = new byte[] { 0, 1, 2 }
                    });
            });

        modelBuilder.Entity("WebFileExplorer.Domain.Folders.Folder", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.Property<Guid?>("ParentId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("ParentId");

                b.ToTable("Folders");

                b.HasData(
                    new
                    {
                        Id = new Guid("11111111-1111-1111-1111-111111111111"),
                        Name = "Root"
                    },
                    new
                    {
                        Id = new Guid("22222222-2222-2222-2222-222222222222"),
                        Name = "Documents",
                        ParentId = new Guid("11111111-1111-1111-1111-111111111111")
                    },
                    new
                    {
                        Id = new Guid("33333333-3333-3333-3333-333333333333"),
                        Name = "Images",
                        ParentId = new Guid("11111111-1111-1111-1111-111111111111")
                    });
            });

        modelBuilder.Entity("WebFileExplorer.Domain.Files.File", b =>
            {
                b.HasOne("WebFileExplorer.Domain.Folders.Folder", "Folder")
                    .WithMany("Files")
                    .HasForeignKey("FolderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Folder");
            });

        modelBuilder.Entity("WebFileExplorer.Domain.Folders.Folder", b =>
            {
                b.HasOne("WebFileExplorer.Domain.Folders.Folder", "Parent")
                    .WithMany("Subfolders")
                    .HasForeignKey("ParentId");

                b.Navigation("Parent");
            });

        modelBuilder.Entity("WebFileExplorer.Domain.Folders.Folder", b =>
            {
                b.Navigation("Files");

                b.Navigation("Subfolders");
            });
#pragma warning restore 612, 618
    }
}
