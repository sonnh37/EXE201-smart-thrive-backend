using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace EXE201.SmartThrive.Domain.Middleware;

public class RequestTokenUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RequestTokenUserMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        InformationUser.User = null;
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token) && token != "null")
            {
                var id = GetUserIdFromToken(token);
                if (id != Guid.Empty)
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {

                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        var userRepository = unitOfWork.UserRepository;
                        var user = await userRepository.GetById(id);
                        InformationUser.User = user;
                    }
                }
            }
        }

        await _next(context);
    }

    private Guid GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        //var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "email");
        var id = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        return Guid.Parse(id);
    }
}