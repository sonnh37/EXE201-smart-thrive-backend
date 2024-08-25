namespace EXE201.SmartThrive.Domain.Entities;

public class Subject : BaseEntity
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Course>? Courses { get; set; }
}