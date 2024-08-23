namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class StudentXPackage : BaseEntity
{
    public Guid? StudentId { get; set; }

    public Guid? PackageId { get; set; }
    
    public string? Status { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Package? Package { get; set; }
}