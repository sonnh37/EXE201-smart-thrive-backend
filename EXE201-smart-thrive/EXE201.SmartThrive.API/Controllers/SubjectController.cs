using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route("api/subject")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService, IMapper mapper)
    {
        _subjectService = subjectService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var msg = await _subjectService.GetAll<SubjectResult>();
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("filtered-sorted-paged")]
    public async Task<IActionResult> GetAllFiltered([FromQuery] SubjectGetAllQuery subjectGetAllQuery)
    {
        try
        {
            var msg = await _subjectService.GetAllFiltered(subjectGetAllQuery);
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
            var msg = await _subjectService.GetById<SubjectResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(SubjectCreateCommand request)
    {
        try
        {
            var msg = await _subjectService.Create(request);
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
            var msg = await _subjectService.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    

    [HttpPut]
    public async Task<IActionResult> Update(SubjectUpdateCommand request)
    {
        try
        {
            var msg = await _subjectService.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}