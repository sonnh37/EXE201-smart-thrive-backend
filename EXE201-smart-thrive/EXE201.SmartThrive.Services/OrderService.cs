using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class OrderService : BaseService<Order>, IOrderService
{
    private readonly IOrderRepository repository;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        repository = _unitOfWork.OrderRepository;
    }

    public async Task<PagedResponse<OrderResult>> GetAllFiltered(OrderGetAllQuery query)
    {
        var total = await repository.GetAllFiltered(query);
        var result = _mapper.Map<List<OrderResult>>(total.Item1);
        var resultWithTotal = (result, total.Item2);

        return ResponseHelper.CreatePaged(resultWithTotal, query);
    }
}