namespace EXE201.SmartThrive.Domain.Models.Results;

public class StudentResult : BaseResult
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public string? Gender { get; set; }

    public DateTime? DOB { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public UserResult? User { get; set; }

    public FeedbackResult? Feedback { get; set; }

    public List<StudentXPackageResult>? StudentXPackages { get; set; }
}