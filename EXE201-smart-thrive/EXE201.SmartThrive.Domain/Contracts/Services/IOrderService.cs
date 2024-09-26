using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IOrderService : IBaseService
{
    Task<string> OrderWithPayment(OrderCreateCommand order);
}