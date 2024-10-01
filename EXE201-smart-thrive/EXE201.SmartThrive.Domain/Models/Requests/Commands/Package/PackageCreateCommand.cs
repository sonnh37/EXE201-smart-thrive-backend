using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Package
{
    public class PackageCreateCommand : CreateCommand
    {
        public Guid StudentId { get; set; }
        public string? Name { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool IsActive { get; set; }

        public PackageStatus? Status { get; set; }
    }
}
