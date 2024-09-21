using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Users)]
[ApiController]
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

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateCommand request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        request.Password = passwordHash;

        var msg = await _userService.Create(request);
        return Ok(msg);
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string usernameOrEmail, string password)
    {
        var msg = await _userService.Login(usernameOrEmail, password);

        return Ok(msg);
    }
}
