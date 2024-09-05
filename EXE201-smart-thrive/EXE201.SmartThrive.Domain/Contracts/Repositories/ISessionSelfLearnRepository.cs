using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories
{
    public interface ISessionSelfLearnRepository : IBaseRepository<SessionSelfLearn>
    {
        Task<SessionSelfLearn> GetBySessionId(Guid sessionId);
    }
}
