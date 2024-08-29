using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void SubjectMapping()
    {
        CreateMap<Subject, SubjectResult>().ReverseMap();
        CreateMap<Subject, SubjectResult>();
        CreateMap<Subject, SubjectCreateCommand>().ReverseMap();
        CreateMap<Subject, SubjectUpdateCommand>().ReverseMap();
    }
}