using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EXE201.SmartThrive.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly IConfiguration configuration;
    private readonly IUserRepository _userRepository;
    private readonly DateTime _expirationTime = ConstantHelper.ExpirationLogin;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration _configuration) : base(mapper, unitOfWork)
    {
        _userRepository = _unitOfWork.UserRepository;
        configuration = _configuration;
    }

    private (string token, string expiration) CreateToken(UserResult user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            configuration.GetSection("JWT:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        
        var token = new JwtSecurityToken(
            claims: claims,
            expires: _expirationTime,
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return (jwt, _expirationTime.ToString("o")); // Trả về token và thời gian hết hạn
    }
    public async Task<BusinessResult> Login(string usernameOrEmail, string password)
    {
        var user = await _userRepository.FindByEmailOrUsername(usernameOrEmail);

        //check username 
        if (user == null) return ResponseHelper.CreateResult(null, null, Const.NOT_USERNAME_MSG);

        //check password
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) 
            return ResponseHelper.CreateResult(null, null, Const.NOT_PASSWORD_MSG);

        var userResult = _mapper.Map<UserResult>(user);
        var (token, expiration) = CreateToken(userResult);

        return ResponseHelper.CreateResult(token, expiration);
    }
}