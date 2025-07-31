using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFileExplorer.Domain;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Infrastructure.Features.Files;

public sealed class FilesConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(ModelConstants.DefaultStringMaxLength);

        builder.Property(c => c.MimeType)
            .IsRequired()
            .HasMaxLength(ModelConstants.DefaultStringMaxLength);
    }
}
