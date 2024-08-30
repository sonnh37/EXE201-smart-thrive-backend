namespace EXE201.SmartThrive.Domain.Entities;

public class SessionMeeting : BaseEntity
{
    public Guid? SessionId { get; set; }
    
    public string? Host { get; set; }
    
    public DateTime? Date { get; set; }

    public string? MeetingUrl { get; set; }

    public string? MeetingPlatform { get; set; }

    public virtual Session? Session { get; set; }
}
