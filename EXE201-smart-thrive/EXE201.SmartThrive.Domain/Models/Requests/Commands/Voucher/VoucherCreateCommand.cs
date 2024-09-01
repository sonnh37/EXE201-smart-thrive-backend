using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Voucher;

public class VoucherCreateCommand : CreateCommand
{
    public string? VoucherType { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? Value { get; set; }

    public int? Condition { get; set; }

    public string? Status { get; set; }
}