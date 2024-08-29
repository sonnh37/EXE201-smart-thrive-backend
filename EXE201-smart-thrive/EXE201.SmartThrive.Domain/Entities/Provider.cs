namespace EXE201.SmartThrive.Domain.Entities;

public class Provider : BaseEntity
{
    public Guid? UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Website { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Course>? Courses { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }
}