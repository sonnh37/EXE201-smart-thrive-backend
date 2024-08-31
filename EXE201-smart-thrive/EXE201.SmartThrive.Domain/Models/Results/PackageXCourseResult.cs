namespace EXE201.SmartThrive.Domain.Models.Results;

public class PackageXCourseResult : BaseResult
{
    public Guid? CourseId { get; set; }

    public Guid? PackageId { get; set; }

    public CourseResult? Course { get; set; }

    public PackageResult? Package { get; set; }
}