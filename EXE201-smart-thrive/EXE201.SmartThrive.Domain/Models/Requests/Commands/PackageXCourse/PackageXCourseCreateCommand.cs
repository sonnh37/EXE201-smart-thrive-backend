using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse
{
    public class PackageXCourseCreateCommand : CreateCommand
    {
        public Guid? CourseId { get; set; }

        public Guid? PackageId { get; set; }
    }
}
