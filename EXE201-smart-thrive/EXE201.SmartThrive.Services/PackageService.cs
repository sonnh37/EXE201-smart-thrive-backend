using AutoMapper;
using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EXE201.SmartThrive.Services
{
    public class PackageService : BaseService<Package>, IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IPackageXCourseRepository _packageXCourseRepository;

        public PackageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _packageRepository = unitOfWork.PackageRepository;
            _packageXCourseRepository = unitOfWork.PackageXCourseRepository;
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

        // public async Task<BusinessResult> Update(PackageUpdateCommand tRequest)
        // {
        //     try
        //     {
        //         // Lấy entity từ repository
        //         var entity = await _packageRepository.GetById(tRequest.Id);
        //         if (entity == null) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
        //
        //         // Xử lý các CourseXPackage
        //         var existingCourses = entity.PackageXCourses.ToList();
        //
        //         // Xóa các CourseXPackage không còn trong tRequest
        //         foreach (var course in existingCourses)
        //         {
        //             if (!tRequest.PackageXCourses.Any(c => c.CourseId == course.CourseId))
        //             {
        //                 _packageXCourseRepository.Remove(course);
        //             }
        //         }
        //
        //         // Thêm mới các CourseXPackage từ tRequest
        //         foreach (var course in tRequest.PackageXCourses)
        //         {
        //             // Kiểm tra xem đã tồn tại trong entity chưa
        //             var existingCourse = existingCourses.FirstOrDefault(c => c.CourseId == course.CourseId);
        //             if (existingCourse == null)
        //             {
        //                 var newPackageXCourse = new PackageXCourse
        //                 {
        //                     CourseId = course.CourseId,
        //                     PackageId = tRequest.Id
        //                 };
        //
        //                 // Detach nếu cần thiết
        //                 var localEntry = await _packageXCourseRepository.GetById(course.CourseId.Value);
        //                 if (localEntry != null)
        //                 {
        //                     _packageXCourseRepository.Context().Entry(localEntry).State = EntityState.Detached;
        //                 }
        //
        //                 _packageXCourseRepository.Add(newPackageXCourse);
        //             }
        //         }
        //
        //         // Cập nhật entity Package
        //         _mapper.Map(tRequest, entity);
        //         SetBaseEntityUpdate(entity);
        //         _packageRepository.Update(entity);
        //
        //         var saveChanges = await _unitOfWork.SaveChanges();
        //         return new BusinessResult(
        //             saveChanges ? Const.SUCCESS_CODE : Const.FAIL_CODE,
        //             saveChanges ? Const.SUCCESS_UPDATE_MSG : Const.FAIL_UPDATE_MSG
        //         );
        //     }
        //     catch (Exception ex)
        //     {
        //         var errorMessage = $"An error occurred while updating {typeof(Package).Name}: {ex.Message}";
        //         Log.Error(ex, errorMessage);
        //         return ResponseHelper.CreateResult(errorMessage);
        //     }
        // }
    }
}