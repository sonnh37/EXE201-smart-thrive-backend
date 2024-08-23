using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class Package : BaseEntity
{
    public Guid? StudentId { get; set; }

    public string? Name { get; set; }

    public int? QuantityCourse { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool IsActive { get; set; }
    
    public string? Status { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<PackageXCourse>? PackageXCourses { get; set; }
    
    public virtual ICollection<StudentXPackage>? StudentXPackages { get; set; }

}