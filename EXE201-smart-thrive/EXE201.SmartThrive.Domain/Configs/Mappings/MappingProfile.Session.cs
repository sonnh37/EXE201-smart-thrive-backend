using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Configs.Mappings;

public partial class MappingProfile : Profile
{
    private void SessionMapping()
    {
        CreateMap<SessionModel, SessionCreateCommand>().ReverseMap();
        CreateMap<SessionModel, SessionUpdateCommand>().ReverseMap();
        CreateMap<SessionModel, Session>().ReverseMap();
        CreateMap<Session, SessionResult>().ReverseMap();
    }
}