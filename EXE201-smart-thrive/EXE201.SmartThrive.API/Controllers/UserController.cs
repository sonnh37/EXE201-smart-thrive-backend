using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.User;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService service;

        public UserController(IUserService _service, IMapper mapper)
        {
            service = _service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var msg = await service.GetAll<UserResult>();
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filtered-sorted-paged")]
        public async Task<IActionResult> GetAllFiltered([FromQuery] UserGetAllQuery query)
        {
            try
            {
                var msg = await service.GetAllFiltered(query);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var msg = await service.GetById<UserResult>(id);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserCreateCommand request)
        {
            try
            {
                var msg = await service.Create(request);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var msg = await service.DeleteById(id);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateCommand request)
        {
            try
            {
                var msg = await service.Update(request);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
