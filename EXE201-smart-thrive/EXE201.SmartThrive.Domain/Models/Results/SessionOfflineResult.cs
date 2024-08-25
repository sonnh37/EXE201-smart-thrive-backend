namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionOfflineResult : BaseResult
{
    public string? Address { get; set; }

    public DateTime? Time { get; set; }

    public int? Duration { get; set; }

    public string? Attribute { get; set; }

    public SessionResult? Session { get; set; }
}