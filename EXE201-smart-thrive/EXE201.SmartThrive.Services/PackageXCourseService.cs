using AutoMapper;
using Azure.Core;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using Serilog;

namespace EXE201.SmartThrive.Services
{
    public class PackageXCourseService : BaseService<PackageXCourse>, IPackageXCourseService
    {
        private readonly IPackageXCourseRepository _packagexcourseRepository;
        private readonly IMapper _mapper;

        public PackageXCourseService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _packagexcourseRepository = unitOfWork.PackageXCourseRepository;
            _mapper = mapper;
        }

        public async Task<BusinessResult> AddToUpdatePackagePrice(PackageXCourseCreateCommand packageXCourse)
        {
            try
            {
                var rs = _packagexcourseRepository.AddToUpdatePackagePrice(_mapper.Map<PackageXCourse>(packageXCourse));
                return new BusinessResult(
                    rs > 0 ? Const.SUCCESS_CODE : Const.FAIL_CODE,
                    rs > 0 ? Const.SUCCESS_CREATE_MSG : Const.FAIL_CREATE_MSG,
                    rs > 0 ? packageXCourse : null
                );
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while creating";
                Log.Error(ex, errorMessage);
                return ResponseHelper.CreateResult(errorMessage);
            }
        }

        public async Task<BusinessResult> DeleteToUpdatePackagePrice(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

                var rs = _packagexcourseRepository.DeleteToUpdatePackagePrice(id);

                return new BusinessResult(
                    rs > 0 ? Const.SUCCESS_CODE : Const.FAIL_CODE,
                    rs > 0 ? Const.SUCCESS_DELETE_MSG : Const.FAIL_DELETE_MSG
                );
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while deleting";
                Log.Error(ex, errorMessage);
                return ResponseHelper.CreateResult(errorMessage);
            }
        }
    }
}
