using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Entities;

public class Package : BaseEntity
{
    public string? Name { get; set; }

    public int? QuantityCourse { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool IsActive { get; set; }
    
    public PackageStatus? Status { get; set; }

    public virtual ICollection<PackageXCourse>? PackageXCourses { get; set; }
    
    public virtual ICollection<Order>? Orders { get; set; }
    
    public virtual ICollection<StudentXPackage>? StudentXPackages { get; set; }

}