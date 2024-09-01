using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.User;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository repository;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        repository = _unitOfWork.UserRepository;
    }

    public async Task<PaginatedResponse<UserResult>> GetAllFiltered(UserGetAllQuery query)
    {
        var total = await repository.GetAllFiltered(query);
        var result = _mapper.Map<List<UserResult>>(total.Item1);
        var resultWithTotal = (result, total.Item2);

        return AppResponse.CreatePaginated(resultWithTotal, query);
    }
}