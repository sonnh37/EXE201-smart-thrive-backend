using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class SessionSelfLearnRepository : BaseRepository<SessionSelfLearn>, ISessionSelfLearnRepository
{
    public SessionSelfLearnRepository(STDbContext context) : base(context)
    {
    }

    public async Task<SessionSelfLearn> GetBySessionId(Guid sessionId)
    {
        var sessionList = await GetAll();
        return sessionList.FirstOrDefault(x => x.SessionId == sessionId);
    }
}