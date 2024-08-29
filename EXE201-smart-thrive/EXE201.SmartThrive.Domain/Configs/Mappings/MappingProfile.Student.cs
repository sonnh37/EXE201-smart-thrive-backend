using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Student;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void StudentMapping()
    {
        CreateMap<Student, StudentResult>().ReverseMap();
        CreateMap<Student, StudentCreateCommand>().ReverseMap();
        CreateMap<Student, StudentUpdateCommand>().ReverseMap();
    }
}