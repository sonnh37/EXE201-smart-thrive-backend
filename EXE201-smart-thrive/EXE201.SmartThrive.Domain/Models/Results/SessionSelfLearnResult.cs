namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionSelfLearnResult : BaseResult
{
    public int? SessionNumber { get; set; }

    public string? VideoURL { get; set; }

    public bool IsComplete { get; set; }

    public SessionResult? Session { get; set; }
}