using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface ISessionOfflineRepository : IBaseRepository<SessionOffline>
{
    Task<SessionOffline> GetBySessionId(Guid sessionId);
}