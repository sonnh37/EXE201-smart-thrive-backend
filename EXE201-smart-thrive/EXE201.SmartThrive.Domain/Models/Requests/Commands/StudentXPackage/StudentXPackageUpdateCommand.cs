using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.StudentXPackage
{
    public class StudentXPackageUpdateCommand: UpdateCommand
    {
        public Guid? StudentId { get; set; }

        public Guid? PackageId { get; set; }

        public StudentXPackageStatus Status { get; set; }

    }
}
