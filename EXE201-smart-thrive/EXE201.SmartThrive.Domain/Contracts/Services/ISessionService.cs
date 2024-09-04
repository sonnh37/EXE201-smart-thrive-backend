using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface ISessionService : IBaseService
{
    Task<object> CreateSession(string type, SessionCreateCommand payload);
}