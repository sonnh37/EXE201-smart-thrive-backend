using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Assistant;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Blog;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{
    [Route(ConstantHelper.Assistants)]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        private readonly IAssistantService _assistantService;

        public AssistantController(IAssistantService assistantService) {
        _assistantService = assistantService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(AssistantCreateCommand request)
        {
            var msg = await _assistantService.Create(request);
            return Ok(msg);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var msg = await _assistantService.GetAll<AssistantResult>();
            return Ok(msg);
        }
    }
}
