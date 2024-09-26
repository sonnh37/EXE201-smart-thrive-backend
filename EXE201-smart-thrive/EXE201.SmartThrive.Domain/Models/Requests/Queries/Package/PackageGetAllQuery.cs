using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Package
{
    public class PackageGetAllQuery : GetAllQuery
    {
        public string? Name { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool IsActive { get; set; }

        public PackageStatus? Status { get; set; }
    }
}
