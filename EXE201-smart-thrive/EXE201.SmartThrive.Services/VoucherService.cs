using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class VoucherService : BaseService<Voucher>, IVoucherService
{
    private readonly IVoucherRepository _voucherRepository;

    public VoucherService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _voucherRepository = unitOfWork.VoucherRepository;
    }

    public async Task<PagedResponse<VoucherResult>> GetAllFiltered(VoucherGetAllQuery query)
    {
        var vouvhersWithTotal = await _voucherRepository.GetAllFiltered(query);
        var vouvhersResult = _mapper.Map<List<VoucherResult>>(vouvhersWithTotal.Item1);
        var vouvhersResultWithTotal = (vouvhersResult, vouvhersWithTotal.Item2);

        return ResponseHelper.CreatePaged(vouvhersResultWithTotal, query);
    }
}