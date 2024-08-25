namespace EXE201.SmartThrive.Domain.Entities;

public class Student : BaseEntity
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public string? Gender { get; set; }

    public DateTime? DOB { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Status { get; set; }

    public virtual User? User { get; set; }
    
    public virtual Feedback? Feedback { get; set; }

    public virtual ICollection<StudentXPackage>? StudentXPackages { get; set; }

}