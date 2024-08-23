using System.ComponentModel.DataAnnotations.Schema;

namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class PackageXCourse : BaseEntity
{
    public Guid? CourseId { get; set; }

    public Guid? PackageId { get; set; }
    
    public string? Status { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Package? Package { get; set; }
}