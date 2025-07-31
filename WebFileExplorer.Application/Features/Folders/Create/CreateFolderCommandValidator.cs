using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebFileExplorer.Application.Abstractions.Data;
using WebFileExplorer.Domain.Folders;

namespace WebFileExplorer.Application.Features.Folders.Create;

public class CreateFolderCommandValidator : AbstractValidator<CreateFolderCommand>
{
    public CreateFolderCommandValidator(IRepository<Folder> folderRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .MustAsync(async (cmd, name, ct) =>
            {
                var exists = await folderRepository
                .QueryAllAsNoTracking()
                .AnyAsync(
                    f => f.Name == name && f.ParentId == cmd.ParentId,
                    ct);
                return !exists;
            })
            .WithMessage("A folder with the same name already exists in this location.");
    }
}
