using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage
{
    public class StudentXPackageCreateCommand : CreateCommand
    {
        public Guid? StudentId { get; set; }

        public Guid? PackageId { get; set; }

        public bool? Status { get; set; }
    }
}
