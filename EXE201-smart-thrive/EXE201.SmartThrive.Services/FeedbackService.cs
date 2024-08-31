using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class FeedbackService : BaseService<Feedback>, IFeedbackService
{
    public FeedbackService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }
}