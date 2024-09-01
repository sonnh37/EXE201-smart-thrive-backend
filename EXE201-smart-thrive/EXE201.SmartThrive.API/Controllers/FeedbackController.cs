using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Feedback;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.SmartThrive.API.Controllers;

[Route(AppConstant.Feedbacks)]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;
    private readonly IMapper _mapper;

    public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
    {
        _feedbackService = feedbackService;
        _mapper = mapper;
        _feedbackService = feedbackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var msg = await _feedbackService.GetAll<FeedbackResult>();
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /*   [HttpGet("filtered-sorted-paged")]
       public async Task<IActionResult> GetAllFiltered([FromQuery] SubjectGetAllQuery subjectGetAllQuery)
       {
           try
           {
               var msg = await _feedbackService.GetAllFiltered(subjectGetAllQuery);
               return Ok(msg);
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
       }*/

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var msg = await _feedbackService.GetById<FeedbackResult>(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(FeedbackCreateCommand request)
    {
        try
        {
            var msg = await _feedbackService.Create(request);
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
            var msg = await _feedbackService.DeleteById(id);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    public async Task<IActionResult> Update(FeedbackUpdateCommand request)
    {
        try
        {
            var msg = await _feedbackService.Update(request);
            return Ok(msg);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}