using AutoMapper;
using File = WebFileExplorer.Domain.Files.File;

namespace WebFileExplorer.Application.Features.Files.Mapping;

public class FileMappingProfile : Profile
{
    public FileMappingProfile()
    {
        CreateMap<File, FileResponse>().ReverseMap();
    }
}
