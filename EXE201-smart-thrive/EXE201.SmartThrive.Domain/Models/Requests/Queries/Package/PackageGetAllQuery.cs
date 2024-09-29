using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Package
{
    public class PackageGetAllQuery : GetAllQuery
    {
        public string? Name { get; set; }

        public int? QuantityCourse { get; set; }

        public decimal? TotalPrice { get; set; }

        public List<bool?>? IsActive { get; set; }

        public List<PackageStatus?>? Status { get; set; }
    }
}
