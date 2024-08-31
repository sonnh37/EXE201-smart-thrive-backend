using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class VoucherResult : BaseResult
{
    public VoucherType? VoucherType { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? Value { get; set; }

    public int? Condition { get; set; }

    public VoucherStatus? Status { get; set; }

    public OrderResult? Order { get; set; }
}