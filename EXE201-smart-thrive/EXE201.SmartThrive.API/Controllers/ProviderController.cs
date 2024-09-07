using System.Text;
using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Providers)]
[ApiController]
public class ProviderController : ControllerBase
{
    private readonly IProviderService service;

    public ProviderController(IProviderService _service)
    {
        service = _service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProviderGetAllQuery query)
    {
        try
        {
            var msg = await service.GetAll<ProviderResult>(query);
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
            var msg = await service.GetById<ProviderResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProviderCreateCommand request)
    {
        try
        {
            var msg = await service.Create(request);
            return Ok(msg);
        }
        catch (DbUpdateException ex)
        {
            // Khởi tạo chuỗi chứa thông tin chi tiết lỗi
            var errorMessage = new StringBuilder();

            // Lấy thông tin chi tiết từ inner exception
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                errorMessage.AppendLine(innerException.Message);
                innerException = innerException.InnerException;
            }

            // Thêm thông tin về ngoại lệ gốc
            errorMessage.AppendLine("Chi tiết lỗi: " + ex.Message);

            // Trả về BadRequest với thông tin lỗi
            return BadRequest(new { Error = errorMessage.ToString() });
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
            var msg = await service.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProviderUpdateCommand request)
    {
        try
        {
            var msg = await service.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}