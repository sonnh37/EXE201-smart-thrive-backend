using AutoMapper;
using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Package;
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
        private readonly STDbContext _stDbContext;

        public PackageService(IMapper mapper, IUnitOfWork unitOfWork, STDbContext _context) : base(mapper, unitOfWork)
        {
            _packageRepository = unitOfWork.PackageRepository;
            _packageXCourseRepository = unitOfWork.PackageXCourseRepository;
            _stDbContext = _context;
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

        public async Task<BusinessResult> Update(PackageUpdateCommand tRequest)
        {
            try
            {
                // Lấy entity từ repository
        var entity = await _packageRepository.GetById(tRequest.Id);
        if (entity == null) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

        // Lấy danh sách CourseId mới từ tRequest
        var newCourseIds = tRequest.PackageXCourses.Select(x => x.CourseId);

        // Tìm các bản ghi cần xóa khỏi entity.PackageXCourses
        var toRemove = entity.PackageXCourses
            .Where(existing => !newCourseIds.Contains(existing.CourseId));
            

        foreach (var item in toRemove)
        {
            _stDbContext.Entry(item).State = EntityState.Detached; // Tách thực thể khỏi tracking
            _packageXCourseRepository.Remove(item); // Gọi Remove cho từng item
        }

        // Thêm hoặc cập nhật các bản ghi mới
        foreach (var newItem in tRequest.PackageXCourses)
        {
            var existingCourse = entity.PackageXCourses
                .SingleOrDefault(existing => existing.CourseId == newItem.CourseId);
                
            if (existingCourse != null)
            {
                // Nếu thực thể đã tồn tại, chỉ cần cập nhật nó
                _mapper.Map(newItem, existingCourse);
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới
                var packageXCourse = new PackageXCourse
                {
                    CourseId = newItem.CourseId,
                    PackageId = tRequest.Id
                };
                entity.PackageXCourses.Add(packageXCourse);
            }
        }

        // Cập nhật các thuộc tính khác của entity
        _mapper.Map(tRequest, entity);
        SetBaseEntityUpdate(entity);
        _packageRepository.Update(entity);

        // Lưu thay đổi
        var saveChanges = await _unitOfWork.SaveChanges();
        return new BusinessResult(
            saveChanges ? Const.SUCCESS_CODE : Const.FAIL_CODE,
            saveChanges ? Const.SUCCESS_UPDATE_MSG : Const.FAIL_UPDATE_MSG
        );
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while updating {typeof(Package).Name}: {ex.Message}";
                Log.Error(ex, errorMessage);
                return ResponseHelper.CreateResult(errorMessage);
            }
        }
    }
}