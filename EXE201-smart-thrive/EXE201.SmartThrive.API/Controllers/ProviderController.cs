using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Providers)]
[ApiController]
public class ProviderController : ControllerBase
{
    private readonly IProviderService _providerService;

    public ProviderController(IProviderService __providerService)
    {
        _providerService = __providerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProviderGetAllQuery query)
    {
        var msg = await _providerService.GetAll<ProviderResult>(query);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _providerService.GetById<ProviderResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProviderCreateCommand request)
    {
        var msg = await _providerService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _providerService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProviderUpdateCommand request)
    {
        var msg = await _providerService.Update(request);
        return Ok(msg);
    }
}