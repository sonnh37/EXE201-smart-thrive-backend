using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class VoucherService : BaseService<Voucher>, IVoucherService
{
    public VoucherService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }
}