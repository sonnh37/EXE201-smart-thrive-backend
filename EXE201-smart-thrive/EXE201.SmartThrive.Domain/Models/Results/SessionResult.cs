using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Results;

public class SessionResult : BaseResult
{
    public Guid? ModuleId { get; set; }
    
    public string? Title { get; set; }
    
    public int? SessionNumber { get; set; }

    public string? Document { get; set; }
    
    public SessionType? SessionType { get; set; }

    public string? Description { get; set; }

    public ModuleResult? Module { get; set; }

    public SessionOfflineResult? SessionOffline { get; set; }

    public SessionMeetingResult? SessionMeeting { get; set; }

    public SessionSelfLearnResult? SessionSelfLearn { get; set; }
}