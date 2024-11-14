using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;
using EXE201.SmartThrive.Domain.Models.Responses;

namespace EXE201.SmartThrive.Domain.Contracts.Services
{
    public interface IPackageXCourseService : IBaseService
    {
        Task<BusinessResult> AddToUpdatePackagePrice(PackageXCourseCreateCommand packageXCourse);
        Task<BusinessResult> DeleteToUpdatePackagePrice(Guid id);
    }
}
