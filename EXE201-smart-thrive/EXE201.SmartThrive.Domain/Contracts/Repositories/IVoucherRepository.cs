using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IVoucherRepository : IBaseRepository<Voucher>
{
    Task<(List<Voucher>, int)> GetAllFiltered(VoucherGetAllQuery query);
}