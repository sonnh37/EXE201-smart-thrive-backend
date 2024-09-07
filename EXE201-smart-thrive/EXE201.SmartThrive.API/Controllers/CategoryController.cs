using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Category;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Categories)]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var msg = await _categoryService.GetAll<CategoryResult>();
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("filtered-sorted-paged")]
    public async Task<IActionResult> GetAllFiltered([FromQuery] CategoryGetAllQuery categoryGetAllQuery)
    {
        try
        {
            var msg = await _categoryService.GetAllFiltered(categoryGetAllQuery);
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
            var msg = await _categoryService.GetById<CategoryResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryCreateCommand request)
    {
        try
        {
            var msg = await _categoryService.Create(request);
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
            var msg = await _categoryService.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateCommand request)
    {
        try
        {
            var msg = await _categoryService.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}