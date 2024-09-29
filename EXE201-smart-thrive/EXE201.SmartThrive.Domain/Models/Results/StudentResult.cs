using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class StudentResult : BaseResult
{
    public Guid? UserId { get; set; }

    public string? StudentName { get; set; }

    public Gender? Gender { get; set; }

    public DateTime? Dob { get; set; }
    public string? ImageAvatar { get; set; }
    public string? Phone { get; set; }

    public UserStatus? Status { get; set; }

    public UserResult? User { get; set; }

    public FeedbackResult? Feedback { get; set; }

    public List<StudentXPackageResult>? StudentXPackages { get; set; }
}