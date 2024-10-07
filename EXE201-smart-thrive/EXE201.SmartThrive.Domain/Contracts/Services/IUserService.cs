using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Responses;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IUserService : IBaseService
{
    Task<BusinessResult> Login(string usernameOrEmail, string password);

    Task<BusinessResult> AddUser(UserCreateCommand user);

    Task<BusinessResult> GetByUsername(string username);

    BusinessResult DecodeToken(string token);

    BusinessResult SendEmail(string email);

    BusinessResult ValidateOtp(string email, string otpInput);
    Task<BusinessResult> RegisterByGoogleAsync(RegisterByGoogleRequest request);
    Task<BusinessResult> LoginByGoogleTokenAsync(VerifyGoogleTokenRequest request);
    Task<BusinessResult> FindAccountRegisteredByGoogle(VerifyGoogleTokenRequest request);
    Task<BusinessResult> GetByUsernameOrEmail(string key);
}