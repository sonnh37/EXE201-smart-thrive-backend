using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Services
{
    public class FeedbackService : BaseService<Feedback>, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IMapper mapper, IUnitOfWork unitOfWork): base(mapper, unitOfWork) 
        {
            _feedbackRepository = _unitOfWork.FeedbackRepository;
        }

        public async Task<PaginatedResponse<FeedbackResult>> GetAllFiltered(FeedbackGetAllQuery query)
        {
            var feedbackTotal = await _feedbackRepository.GetAllFiltered(query);
            var feedbackResult = _mapper.Map<List<FeedbackResult>>(feedbackTotal.Item1);
            var feedbackResultWithTotal = (feedbackResult, feedbackTotal.Item2);

            return AppResponse.CreatePaginated(feedbackResultWithTotal, query);
        }
    }
}
