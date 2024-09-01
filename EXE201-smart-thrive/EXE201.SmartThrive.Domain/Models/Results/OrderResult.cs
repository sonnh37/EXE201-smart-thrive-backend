using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class OrderResult : BaseResult
{
    public Guid? PackageId { get; set; }

    public Guid? VoucherId { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Description { get; set; }

    public OrderStatus? Status { get; set; }

    public PackageResult? Package { get; set; }

    public VoucherResult? Voucher { get; set; }
}