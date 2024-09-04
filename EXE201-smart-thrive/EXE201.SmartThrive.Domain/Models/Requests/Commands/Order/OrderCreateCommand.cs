using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;

public class OrderCreateCommand : CreateCommand
{
    public Guid? PackageId { get; set; }

    public Guid? VoucherId { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Description { get; set; }

    public OrderStatus? Status { get; set; }
}