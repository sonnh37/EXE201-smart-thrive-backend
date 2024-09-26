using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;

public class VoucherGetAllQuery : GetAllQuery
{
    public VoucherType? VoucherType { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }
}