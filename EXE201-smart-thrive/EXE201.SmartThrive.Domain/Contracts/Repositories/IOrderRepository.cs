using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
}