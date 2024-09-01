using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Bases;
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
    public class SessionSelfLearnRepository : BaseRepository<SessionSelfLearn>, ISessionSelfLearnRepository
    {
        public SessionSelfLearnRepository(STDbContext context) : base(context)
        {

        }
    }
}
