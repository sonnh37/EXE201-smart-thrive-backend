using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class Category : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Subject>? Subjects { get; set; }
}