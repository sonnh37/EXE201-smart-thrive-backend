using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Contracts.Services
{
    public interface ISessionService : IBaseService
    {
        Task<object> CreateSession(string type, SessionCreateCommand payload);
    }
}
