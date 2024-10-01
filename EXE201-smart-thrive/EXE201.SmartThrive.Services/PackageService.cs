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

        public async Task<BusinessResult> CreateWithStudentId(PackageCreateCommand request)
        {
            var foundStudent = await this._unitOfWork.GetRepositoryByEntity<Student>().GetById(request.StudentId);
            if (foundStudent == null)
            {
                throw new NotImplementException("Student not found");
            }
            var package = await this.CreateEntity(request);
            if (package == null)
            {
                throw new NotImplementException("Package create fail");
            }
            var studentXPackage = new StudentXPackage
            {
                StudentId = request.StudentId,
                PackageId = package.Id
            };
            _unitOfWork.GetRepositoryByEntity<StudentXPackage>().Add(studentXPackage);
            await _unitOfWork.SaveChanges();
            return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_CREATE_MSG, studentXPackage);

        }
    }
}
