namespace EXE201.SmartThrive.Domain.Entities;

public class StudentXPackage : BaseEntity
{
    public Guid? StudentId { get; set; }

    public Guid? PackageId { get; set; }
    
    public virtual Student? Student { get; set; }

    public virtual Package? Package { get; set; }
}