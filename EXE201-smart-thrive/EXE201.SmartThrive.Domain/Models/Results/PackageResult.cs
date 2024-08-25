namespace EXE201.SmartThrive.Domain.Models.Results;

public class PackageResult : BaseResult
{
    public Guid? StudentId { get; set; }

    public string? Name { get; set; }

    public int? QuantityCourse { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool IsActive { get; set; }

    public string? Status { get; set; }

    public OrderResult? Order { get; set; }

    public List<PackageXCourseResult>? PackageXCourses { get; set; }

    public List<StudentXPackageResult>? StudentXPackages { get; set; }
}