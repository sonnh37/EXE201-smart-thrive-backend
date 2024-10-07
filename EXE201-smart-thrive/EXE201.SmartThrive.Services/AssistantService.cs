using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services
{
    public class AssistantService : BaseService<Assistant>, IAssistantService
    {
        private readonly IAssistantRepository assistantRepository;
        public AssistantService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this.assistantRepository = _unitOfWork.AssistantRepository;
        }
    }
}
