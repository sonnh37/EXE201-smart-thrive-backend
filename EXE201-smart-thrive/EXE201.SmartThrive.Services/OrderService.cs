using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

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
        var response = await Create(order);

        if (response.Status != Const.SUCCESS_CODE)
        {
            throw new NotImplementException("Order not created");
        }

        var orderModel = response.Data as Order;
        var qr = await paymentService.CreateQrCode("Thanh toán Package", orderModel.Id);
        if (qr is null)
        {
            throw new NotImplementException("Create QR payment fail");
        }
        return qr;
    }
}