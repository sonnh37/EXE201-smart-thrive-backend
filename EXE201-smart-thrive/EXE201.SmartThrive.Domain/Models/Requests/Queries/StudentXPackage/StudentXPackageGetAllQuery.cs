using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.StudentXPackage
{
    public class StudentXPackageGetAllQuery : GetAllQuery
    {
        public Guid? StudentId { get; set; }

        public Guid? PackageId { get; set; }
    }
}
