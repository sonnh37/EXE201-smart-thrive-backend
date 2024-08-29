using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Category;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void CategoryMapping()
    {
        CreateMap<Category, CategoryResult>().ReverseMap();
        CreateMap<Category, CategoryCreateCommand>().ReverseMap();
        CreateMap<Category, CategoryUpdateCommand>().ReverseMap();
    }
}