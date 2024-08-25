namespace EXE201.SmartThrive.Domain.Entities;

public class Category : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Subject>? Subjects { get; set; }
}