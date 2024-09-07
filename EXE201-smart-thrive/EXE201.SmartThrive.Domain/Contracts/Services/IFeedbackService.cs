using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IFeedbackService : IBaseService
{
    Task<PagedResponse<FeedbackResult>> GetAllFiltered(FeedbackGetAllQuery query);
}