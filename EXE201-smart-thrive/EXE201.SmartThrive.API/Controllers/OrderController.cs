using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Orders)]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService service;

    public OrderController(IOrderService _service)
    {
        service = _service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] OrderGetAllQuery query)
    {
        var msg = await service.GetAll<OrderResult>(query);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await service.GetById<OrderResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(OrderCreateCommand request)
    {
        var msg = await service.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await service.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(OrderUpdateCommand request)
    {
        var msg = await service.Update(request);
        return Ok(msg);
    }
}