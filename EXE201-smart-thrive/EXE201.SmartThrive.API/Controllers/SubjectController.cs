using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Subjects)]
[ApiController]
[Authorize]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] SubjectGetAllQuery subjectGetAllQuery)
    {
        var msg = await _subjectService.GetAll<SubjectResult>(subjectGetAllQuery);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _subjectService.GetById<SubjectResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SubjectCreateCommand request)
    {
        var msg = await _subjectService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _subjectService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(SubjectUpdateCommand request)
    {
        var msg = await _subjectService.Update(request);
        return Ok(msg);
    }
}