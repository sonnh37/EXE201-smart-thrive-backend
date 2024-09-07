using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Blogs)]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var msg = await _blogService.GetAll<BlogResult>();
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
            var msg = await _blogService.GetById<BlogResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(BlogCreateCommand request)
    {
        try
        {
            var msg = await _blogService.Create(request);
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
            var msg = await _blogService.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    public async Task<IActionResult> Update(BlogUpdateCommand request)
    {
        try
        {
            var msg = await _blogService.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("filtered-sorted-paged")]
    public async Task<IActionResult> GetAllFiltered([FromQuery] BlogGetAllQuery request)
    {
        try
        {
            var msg = await _blogService.GetAllFiltered(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}