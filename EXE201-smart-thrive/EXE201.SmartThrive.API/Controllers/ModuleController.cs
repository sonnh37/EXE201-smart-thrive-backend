using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Module;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Modules)]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public ModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var msg = await _moduleService.GetAll<ModuleResult>();
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("filtered-sorted-paged")]
    public async Task<IActionResult> GetAllFiltered([FromQuery] ModuleGetAllQuery request)
    {
        try
        {
            var msg = await _moduleService.GetAllFiltered(request);
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
            var msg = await _moduleService.GetById<ModuleResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(ModuleCreateCommand request)
    {
        try
        {
            var msg = await _moduleService.Create(request);
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
            var msg = await _moduleService.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    public async Task<IActionResult> Update(ModuleUpdateCommand request)
    {
        try
        {
            var msg = await _moduleService.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}