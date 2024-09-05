using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class SessionMeetingRepository : BaseRepository<SessionMeeting>, ISessionMeetingRepository
{
    public SessionMeetingRepository(STDbContext context) : base(context)
    {
        
    }
    public async Task<SessionMeeting> GetBySessionId(Guid sessionId)
    {
        var sessionList = await base.GetAll();
        return sessionList.FirstOrDefault(x => x.SessionId == sessionId);
    }
}