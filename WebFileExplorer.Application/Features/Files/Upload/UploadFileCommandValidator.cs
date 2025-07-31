using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;

namespace WebFileExplorer.Application.Features.Files.Upload;

public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
{
    private readonly IRepository<Folder> _folderRepositrory;
    public UploadFileCommandValidator(IRepository<Folder> folderRepository)
    {
        _folderRepositrory = folderRepository;
        
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File cannot be null.")
            .Must(file => file.Length > 0)
            .WithMessage("File cannot be empty.");

        RuleFor(x => x.FolderId)
            .MustAsync(FolderExists)
            .WithMessage("The specified folder does not exist.");
    }

    private async Task<bool> FolderExists(Guid folderId, CancellationToken cancellationToken) =>
        await _folderRepositrory
            .QueryAllAsNoTracking()
            .AnyAsync(c => c.Id == folderId, cancellationToken);
}
