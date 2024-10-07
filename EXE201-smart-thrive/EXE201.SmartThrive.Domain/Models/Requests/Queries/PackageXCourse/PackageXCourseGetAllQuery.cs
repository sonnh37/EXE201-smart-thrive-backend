using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.PackageXCourse
{
    public class PackageXCourseGetAllQuery : GetAllQuery
    {
        public Guid? CourseId { get; set; }

        public Guid? PackageId { get; set; }
    }
}
