using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Package;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Packages)]
[ApiController]
public class PackageController : ControllerBase
{
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PackageGetAllQuery query)
    {
        var msg = await _packageService.GetAll<PackageResult>(query);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _packageService.GetById<PackageResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PackageCreateCommand request)
    {
        var msg = await _packageService.Create(request);
        return Ok(msg);
    }

    [HttpPost("createWithStudent")]
    public async Task<IActionResult> AddWithStudent(PackageCreateWithStudentCommand request)
    {
        var msg = await _packageService.CreateWithStudentId(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _packageService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(PackageUpdateCommand request)
    {
        var msg = await _packageService.Update(request);
        return Ok(msg);
    }
}