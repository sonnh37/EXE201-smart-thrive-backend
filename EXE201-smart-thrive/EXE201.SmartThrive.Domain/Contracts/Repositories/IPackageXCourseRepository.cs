using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories
{
    public interface IPackageXCourseRepository : IBaseRepository<PackageXCourse>
    {
        int AddToUpdatePackagePrice(PackageXCourse packageXCourse);
        int DeleteToUpdatePackagePrice(Guid id);
    }
}
