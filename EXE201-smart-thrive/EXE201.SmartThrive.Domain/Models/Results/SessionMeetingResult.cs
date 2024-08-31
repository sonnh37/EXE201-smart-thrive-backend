namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionMeetingResult : BaseResult
{
    public Guid? SessionId { get; set; }
    
    public string? Host { get; set; }
    
    public DateTime? Date { get; set; }

    public string? MeetingUrl { get; set; }
    
    public string? MeetingPlatform { get; set; }

    public SessionResult? Session { get; set; }
}