using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class Subject : BaseEntity
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Course>? Courses { get; set; }
}