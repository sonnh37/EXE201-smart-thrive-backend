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

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CategoryGetAllQuery categoryGetAllQuery)
    {
        var msg = await _categoryService.GetAll<CategoryResult>(categoryGetAllQuery);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _categoryService.GetById<CategoryResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryCreateCommand request)
    {
        var msg = await _categoryService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _categoryService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateCommand request)
    {
        var msg = await _categoryService.Update(request);
        return Ok(msg);
    }
}