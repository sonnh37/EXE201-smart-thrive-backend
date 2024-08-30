using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class PackageResult : BaseResult
{
    public string? Name { get; set; }

    public int? QuantityCourse { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool IsActive { get; set; }

    public PackageStatus? Status { get; set; }

    public List<PackageXCourseResult>? PackageXCourses { get; set; }
    
    public List<OrderResult>? Orders { get; set; }

    public List<StudentXPackageResult>? StudentXPackages { get; set; }
}