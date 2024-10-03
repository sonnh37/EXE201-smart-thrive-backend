using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface ISessionRepository : IBaseRepository<Session>
{
    public Task<IList<SessionSchedule>> GetSessionsByStudentId(Guid studentId);

    public Task<IList<SessionComming>> Get4CommingSessionsByStudentId(Guid studentId);
}