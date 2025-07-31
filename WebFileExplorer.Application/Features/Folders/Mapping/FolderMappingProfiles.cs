using AutoMapper;
using WebFileExplorer.Application.Features.Folders.Create;
using WebFileExplorer.Domain.Folders;

namespace WebFileExplorer.Application.Features.Folders.Mapping;

public class FolderMappingProfiles : Profile
{
    public FolderMappingProfiles()
    {
        CreateMap<Folder, FolderResponse>().ReverseMap();
        CreateMap<CreateFolderCommand, Folder>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());  // ignore Id because DB generates it
    }
}
