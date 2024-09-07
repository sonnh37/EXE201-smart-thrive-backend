using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface ISessionMeetingRepository : IBaseRepository<SessionMeeting>
{
    Task<SessionMeeting> GetBySessionId(Guid id);
}