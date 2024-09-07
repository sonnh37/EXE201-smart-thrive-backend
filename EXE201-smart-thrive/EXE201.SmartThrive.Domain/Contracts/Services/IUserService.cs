using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IUserService : IBaseService
{
    Task<PagedResponse<UserResult>> GetAllFiltered(UserGetAllQuery query);
    Task<UserResult> Login(string usernameOrEmail, string password);
    Task<string> CreateToken(UserResult user);
}