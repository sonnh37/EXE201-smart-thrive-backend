using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Repositories
{
    public class SessionOfflineRepository : BaseRepository<SessionOffline>, ISessionOfflineRepository
    {
        public SessionOfflineRepository(STDbContext context):base(context)
        {

        }
        public async Task<SessionOffline> GetBySessionId(Guid sessionId)
        {
            var sessionList = await base.GetAll();
            return sessionList.FirstOrDefault(x => x.SessionId == sessionId);
        }
    }
}