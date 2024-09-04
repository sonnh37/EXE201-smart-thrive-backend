using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class ProviderService : BaseService<Provider>, IProviderService
{
    private readonly IProviderRepository repository;

    public ProviderService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        repository = _unitOfWork.ProviderRepository;
    }

    public async Task<PaginatedResponse<ProviderResult>> GetAllFiltered(ProviderGetAllQuery query)
    {
        var total = await repository.GetAllFiltered(query);
        var result = _mapper.Map<List<ProviderResult>>(total.Item1);
        var resultWithTotal = (result, total.Item2);

        return AppResponse.CreatePaginated(resultWithTotal, query);
    }
}