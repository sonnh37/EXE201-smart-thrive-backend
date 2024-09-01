namespace EXE201.SmartThrive.Domain.Entities;

public class Feedback : BaseEntity
{
    public Guid? StudentId { get; set; }

    public Guid? CourseId { get; set; }

    public string? Description { get; set; }

    public int? Rating { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Course? Course { get; set; }
}