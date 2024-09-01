using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Module;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void ModuleMapping()
    {
        CreateMap<Module, ModuleResult>().ReverseMap();
        CreateMap<Module, ModuleCreateCommand>().ReverseMap();
        CreateMap<Module, ModuleUpdateCommand>().ReverseMap();
    }
}