namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionOfflineResult : BaseResult
{
    public Guid? SessionId { get; set; }
    
    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public int? Duration { get; set; }

    public SessionResult? Session { get; set; }
}