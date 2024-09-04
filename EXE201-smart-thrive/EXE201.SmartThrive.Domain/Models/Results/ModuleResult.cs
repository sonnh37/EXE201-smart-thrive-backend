namespace EXE201.SmartThrive.Domain.Models.Results;

public class ModuleResult : BaseResult
{
    public Guid? CourseId { get; set; }

    public int? ModuleNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public CourseResult? Course { get; set; }

    public List<SessionResult>? Sessions { get; set; }
}