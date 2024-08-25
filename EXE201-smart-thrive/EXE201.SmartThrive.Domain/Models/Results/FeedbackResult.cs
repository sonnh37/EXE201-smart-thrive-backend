namespace EXE201.SmartThrive.Domain.Models.Results;

public class FeedbackResult : BaseResult
{
    public Guid? StudentId { get; set; }

    public Guid? CourseId { get; set; }

    public string? Description { get; set; }

    public int? Rating { get; set; }

    public StudentResult? Student { get; set; }

    public CourseResult? Course { get; set; }
}