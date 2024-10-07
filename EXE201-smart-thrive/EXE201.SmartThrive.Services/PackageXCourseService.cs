using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services
{
    public class PackageXCourseService : BaseService<PackageXCourse>, IPackageXCourseService
    {
        private readonly IPackageXCourseRepository _repository;

        public PackageXCourseService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.PackageXCourseRepository;
        }
    }
}
