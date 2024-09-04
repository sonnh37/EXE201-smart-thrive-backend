using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;



namespace EXE201.SmartThrive.Services
{
    public class ModuleService : BaseService<Module>, IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _moduleRepository = unitOfWork.ModuleRepository;
        }

        public async Task<PaginatedResponse<ModuleResult>> GetAllFiltered(ModuleGetAllQuery query)
        {
            var modulesWithTotal = await _moduleRepository.GetAllFiltered(query);
            var modulesResult = _mapper.Map<List<ModuleResult>>(modulesWithTotal.Item1);
            var modulesResultWithTotal = (modulesResult, modulesWithTotal.Item2);

            return AppResponse.CreatePaginated(modulesResultWithTotal, query);
        }
    }
}
