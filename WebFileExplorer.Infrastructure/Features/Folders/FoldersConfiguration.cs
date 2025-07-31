using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFileExplorer.Domain;
using WebFileExplorer.Domain.Folders;

namespace WebFileExplorer.Infrastructure.Features.Folders;

public sealed class FoldersConfiguration : IEntityTypeConfiguration<Folder>
{
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(ModelConstants.DefaultStringMaxLength);
    }
}
