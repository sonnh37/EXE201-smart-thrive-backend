namespace EXE201.SmartThrive.Domain.Models.Results;

public class ProviderResult : BaseResult
{
    public Guid? UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? Website { get; set; }

    public UserResult? User { get; set; }

    public List<CourseResult>? Courses { get; set; }
}