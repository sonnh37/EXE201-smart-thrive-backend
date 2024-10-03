using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface ISessionService : IBaseService
{
    Task<BusinessResult> GetById(Guid id);
    Task<BusinessResult> CreateSession(string type, SessionCreateCommand payload);
    Task<BusinessResult> UpdateSession(string type, SessionUpdateCommand payload);
    Task<BusinessResult> DeleteSession(Guid sessionId);
}