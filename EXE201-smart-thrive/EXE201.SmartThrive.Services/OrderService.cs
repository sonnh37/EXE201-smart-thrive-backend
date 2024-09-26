using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class OrderService : BaseService<Order>, IOrderService
{
    private readonly IOrderRepository repository;
    private readonly IPaymentService paymentService;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IPaymentService paymentService) : base(mapper, unitOfWork)
    {
        repository = _unitOfWork.OrderRepository;
        this.paymentService = paymentService;
    }

    public async Task<string> OrderWithPayment(OrderCreateCommand order)
    {
        var orderModel = await this.CreateEntity(order);
        var qr = await paymentService.CreateQrCode("Thanh toán đơn hàng Package", orderModel.Id);
        return qr;
    }
}