using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Feedback;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(ConstantHelper.Feedbacks)]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FeedbackGetAllQuery request)
    {
        var msg = await _feedbackService.GetAll<FeedbackResult>(request);
        return Ok(msg);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var msg = await _feedbackService.GetById<FeedbackResult>(id);
        return Ok(msg);
    }

    [HttpPost]
    public async Task<IActionResult> Add(FeedbackCreateCommand request)
    {
        var msg = await _feedbackService.Create(request);
        return Ok(msg);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var msg = await _feedbackService.DeleteById(id);
        return Ok(msg);
    }

    [HttpPut]
    public async Task<IActionResult> Update(FeedbackUpdateCommand request)
    {
        var msg = await _feedbackService.Update(request);
        return Ok(msg);
    }
}