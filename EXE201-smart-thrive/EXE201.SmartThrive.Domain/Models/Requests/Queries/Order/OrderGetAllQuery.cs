using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Order;

public class OrderGetAllQuery : GetAllQuery
{
    public Guid? PackageId { get; set; }

    public Guid? VoucherId { get; set; }

    public List<PaymentMethod>? PaymentMethod { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Description { get; set; }

    public List<OrderStatus>? Status { get; set; }
}