using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
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

    public BusinessResult DecodeToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        // Kiểm tra nếu token không hợp lệ
        if (!handler.CanReadToken(token))
        {
            throw new ArgumentException("Token không hợp lệ", nameof(token));
        }

        // Giải mã token
        var jwtToken = handler.ReadJwtToken(token);

        // Truy xuất các thông tin từ token
        var id = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        var name = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        var role = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        var exp = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Expiration).Value;


        // Tạo đối tượng DecodedToken
        var decodedToken = new DecodedToken
        {
            Id = id,
            Name = name,
            Role = role,
            Exp = long.Parse(exp),
        };

        return new BusinessResult(Const.SUCCESS_CODE, "Decoded to get user", decodedToken);
    }
    private (string token, string expiration) CreateToken(UserResult user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Expiration, new DateTimeOffset(_expirationTime).ToUnixTimeSeconds().ToString())
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

    public async Task<BusinessResult> AddUser(UserCreateCommand user)
    {
        var username = await _userRepository.FindByEmailOrUsername(user.Username);
        //    var email = await _userRepository.FindByEmailOrUsername(user.Email);
        if (username == null)
        {
            return await Create(user);
        }
        else
        {
            return new BusinessResult(Const.FAIL_CODE, "Username đã tồn tại");
        }
    }

    public async Task<BusinessResult> GetByUsername(string username)
    {
        var user = await _userRepository.GetByUsername(username);

        var userResult = _mapper.Map<UserResult>(user);

        if (user != null)
        {
            return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_READ_MSG, userResult);
        }
        else
        {
            return new BusinessResult(Const.FAIL_CODE, "Username khong ton tai", userResult);
        }
    }
}