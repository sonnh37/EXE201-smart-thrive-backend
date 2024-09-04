using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class SessionOfflineRepository : BaseRepository<SessionOffline>, ISessionOfflineRepository
{
    public SessionOfflineRepository(STDbContext context) : base(context)
    {
    }
}