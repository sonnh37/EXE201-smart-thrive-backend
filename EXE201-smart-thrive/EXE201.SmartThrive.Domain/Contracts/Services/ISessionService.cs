using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface ISessionService : IBaseService
{
    Task<Session> CreateSession(string type, SessionCreateCommand payload);
    Task<Session> UpdateSession(string type, SessionUpdateCommand payload);
    Task DeleteSession(Guid sessionId);
}