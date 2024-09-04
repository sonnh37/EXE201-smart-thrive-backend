namespace EXE201.SmartThrive.Domain.Entities;

public class PackageXCourse : BaseEntity
{
    public Guid? CourseId { get; set; }

    public Guid? PackageId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Package? Package { get; set; }
}