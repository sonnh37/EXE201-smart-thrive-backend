namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionMeetingResult : BaseResult
{
    public string? Host { get; set; }

    public string? MeetingUrl { get; set; }

    public string? MeetingPlatform { get; set; }

    public string? AccessCode { get; set; }

    public SessionResult? Session { get; set; }
}