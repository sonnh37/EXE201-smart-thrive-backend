using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.PackageXCourse;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Package
{
    public class PackageUpdateCommand : UpdateCommand
    {
        public string? Name { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool IsActive { get; set; }

        public PackageStatus? Status { get; set; }
        
        public List<PackageXCourseUpdateCommand>? PackageXCourses { get; set; }
    }
}
