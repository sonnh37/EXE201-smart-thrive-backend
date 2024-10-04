using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Exceptions;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services
{
    public class PackageService : BaseService<Package>, IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _packageRepository = unitOfWork.PackageRepository;
        }

        public async Task<BusinessResult> CreateWithStudentId(PackageCreateWithStudentCommand request)
        {
            var foundStudent = await this._unitOfWork.GetRepositoryByEntity<Student>().GetById(request.StudentId);
            if (foundStudent == null)
            {
                throw new NotImplementException("Student not found");
            }

            var response = await Create(request);

            if (response.Status != Const.SUCCESS_CODE)
            {
                throw new NotImplementException("Package create fail");
            }

            var package = response.Data as Package;
            var studentXPackage = new StudentXPackage
            {
                StudentId = request.StudentId,
                PackageId = package?.Id
            };
            _unitOfWork.GetRepositoryByEntity<StudentXPackage>().Add(studentXPackage);
            await _unitOfWork.SaveChanges();
            return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_CREATE_MSG, studentXPackage);

        }
    }
}
