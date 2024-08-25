namespace EXE201.SmartThrive.Domain.Models.Results;

public class SubjectResult : BaseResult
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }

    public CategoryResult? Category { get; set; }

    public List<CourseResult>? Courses { get; set; }
}