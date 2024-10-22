using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Users)]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(IUserService __userService)
    {
        _userService = __userService;
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UserGetAllQuery query)
    {
        var msg = await _userService.GetAll<UserResult>(query);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _userService.GetById<UserResult>(id);
        return Ok(msg);
    }

    //[HttpGet("{username}")]
    //public async Task<IActionResult> GetByUsername([FromRoute] string username)
    //{
    //    var msg = await _userService.GetByUsername(username);
    //    return Ok(msg);
    //}

    [HttpGet("username-or-email")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByUsernameOrEmail([FromQuery] string key)
    {
        var msg = await _userService.GetByUsernameOrEmail(key);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserCreateCommand request)
    {
        var msg = await _userService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _userService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateCommand request)
    {
        var msg = await _userService.Update(request);
        return Ok(msg);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateCommand request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        request.Password = passwordHash;

        var msg = await _userService.AddUser(request);
        return Ok(msg);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
    {
        var msg = await _userService.Login(request.UsernameOrEmail, request.Password);

        return Ok(msg);
    }

    [AllowAnonymous]
    [HttpPost("decode-token")]
   
    public IActionResult DecodeToken([FromBody] TokenRequest request)
    {
        try
        {
            var br = _userService.DecodeToken(request.Token);

            return Ok(br);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [AllowAnonymous]
    [HttpPost("send-email")]
    public IActionResult SendOTP([FromBody] EmailRequest request)
    {
        try
        {
            var br = _userService.SendEmail(request.Email);
            return Ok(br);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("verify-otp")]
    public IActionResult VerifyOTP([FromBody] VerifyOtpRequest request)
    {
        try
        {
            var response = _userService.ValidateOtp(request.Email.ToLower(), request.Otp);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [AllowAnonymous]
    [HttpPost("find-account-registered-by-google")]
    public async Task<IActionResult> FindAccountRegisteredByGoogle([FromBody] VerifyGoogleTokenRequest request)
    {
        try
        {
            var response = await _userService.FindAccountRegisteredByGoogle(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost("login-by-google")]
    public async Task<IActionResult> LoginByGoogle([FromBody] VerifyGoogleTokenRequest request)
    {
        try
        {
            var response = await _userService.LoginByGoogleTokenAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost("register-by-google")]
    public async Task<IActionResult> RegisterByGoogle([FromBody] RegisterByGoogleRequest request)
    {
        try
        {
            var response = await _userService.RegisterByGoogleAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
