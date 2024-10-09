using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.StudentXPackage;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{
    [Route(ConstantHelper.StudentXPackage)]
    [ApiController]
    [Authorize]
    public class StudentXPackageController : ControllerBase
    {
        private readonly IStudentXPackageService _service;

        public StudentXPackageController(IStudentXPackageService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] StudentXPackageGetAllQuery getAllQuery)
        {
            var msg = await _service.GetAll<StudentXPackageResult>(getAllQuery);
            return Ok(msg);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var msg = await _service.GetById<StudentXPackageResult>(id);
            return Ok(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentXPackageCreateCommand request)
        {
            var msg = await _service.Create(request);
            return Ok(msg);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var msg = await _service.DeleteById(id);
            return Ok(msg);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentXPackageUpdateCommand request)
        {
            var msg = await _service.Update(request);
            return Ok(msg);
        }
    }
}
