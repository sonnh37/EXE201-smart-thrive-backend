using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers
{
    [Route(ConstantHelper.PackageXCourse)]
    [ApiController]
    [Authorize]
    public class PackageXCourseController : ControllerBase
    {
        private readonly IPackageXCourseService _service;

        public PackageXCourseController(IPackageXCourseService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] PackageXCourseGetAllQuery getAllQuery)
        {
            var msg = await _service.GetAll<PackageXCourseResult>(getAllQuery);
            return Ok(msg);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var msg = await _service.GetById<PackageXCourseResult>(id);
            return Ok(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PackageXCourseCreateCommand request)
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
        public async Task<IActionResult> Update(PackageXCourseUpdateCommand request)
        {
            var msg = await _service.Update(request);
            return Ok(msg);
        }
    }
}
