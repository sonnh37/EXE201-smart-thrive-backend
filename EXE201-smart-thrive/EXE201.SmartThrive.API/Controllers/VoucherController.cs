using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Voucher;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Vouchers)]
[ApiController]
public class VoucherController : ControllerBase
{
    private readonly IVoucherService _voucherService;

    public VoucherController(IVoucherService voucherService)
    {
        _voucherService = voucherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] VoucherGetAllQuery request)
    {
        var msg = await _voucherService.GetAll<VoucherResult>(request);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _voucherService.GetById<VoucherResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(VoucherCreateCommand request)
    {
        var msg = await _voucherService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _voucherService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(VoucherUpdateCommand request)
    {
        var msg = await _voucherService.Update(request);
        return Ok(msg);
    }
}