using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IVoucherService : IBaseService
{
    Task<PagedResponse<VoucherResult>> GetAllFiltered(VoucherGetAllQuery query);
}