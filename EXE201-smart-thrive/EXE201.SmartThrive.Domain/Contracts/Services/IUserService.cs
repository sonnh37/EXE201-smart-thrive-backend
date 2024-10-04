using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IUserService : IBaseService
{
    Task<BusinessResult> Login(string usernameOrEmail, string password);
    Task<BusinessResult> AddUser(UserCreateCommand user);
    Task<BusinessResult> GetByUsername(string username);
}