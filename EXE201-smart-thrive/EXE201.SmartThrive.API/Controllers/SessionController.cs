using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;

        public SessionController(IMapper mapper, ISessionService sessionService)
        {
            _mapper = mapper;
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SessionCreateCommand request)
        {
            try
            {
                var result = await _sessionService.CreateSession(request.SessionType.ToString(), request);
                return Ok(result);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
