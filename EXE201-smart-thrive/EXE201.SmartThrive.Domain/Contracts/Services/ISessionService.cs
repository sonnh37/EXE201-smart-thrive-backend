using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Domain.Models.Responses;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface ISessionService : IBaseService
{
    public Task<BusinessResult> GetSessionsByStudentId(Guid studentId);

    public Task<BusinessResult> Get4CommingSessionsByStudentId(Guid studentId);

    Task<BusinessResult> GetById(Guid id);
    Task<BusinessResult> CreateSession(string type, SessionCreateCommand payload);
    Task<BusinessResult> UpdateSession(string type, SessionUpdateCommand payload);
    Task<BusinessResult> DeleteSession(Guid sessionId);
}