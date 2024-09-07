using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class FeedbackService : BaseService<Feedback>, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _feedbackRepository = unitOfWork.FeedbackRepository;
    }
}