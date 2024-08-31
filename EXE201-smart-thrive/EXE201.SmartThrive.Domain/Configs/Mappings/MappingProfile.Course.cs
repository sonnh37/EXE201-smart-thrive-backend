using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Course;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void CourseMapping()
    {
        CreateMap<Course, CourseResult>().ReverseMap();
        CreateMap<Course, CourseCreateCommand>().ReverseMap();
        CreateMap<Course, CourseUpdateCommand>().ReverseMap();
    }
}