namespace EXE201.SmartThrive.Domain.Entities;

public class Session : BaseEntity
{
    public Guid? ModuleId { get; set; }
    
    public string? Title { get; set; }

    public string? Document { get; set; }
    
    public string? SessionType { get; set; }

    public string? Description { get; set; }

    public virtual Module? Module { get; set; }
    
    public virtual SessionOffline? SessionOffline { get; set; }
    
    public virtual SessionMeeting? SessionMeeting { get; set; }
    
    public virtual SessionSelfLearn? SessionSelfLearn { get; set; }
}