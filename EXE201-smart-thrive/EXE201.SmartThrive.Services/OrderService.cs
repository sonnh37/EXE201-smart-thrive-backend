using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Provider;
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
    public class OrderService: BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository repository;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            repository = _unitOfWork.OrderRepository;
        }

        public async Task<PaginatedResponse<OrderResult>> GetAllFiltered(OrderGetAllQuery query)
        {
            var total = await repository.GetAllFiltered(query);
            var result = _mapper.Map<List<OrderResult>>(total.Item1);
            var resultWithTotal = (result, total.Item2);

            return AppResponse.CreatePaginated(resultWithTotal, query);
        }
    }
}
