namespace EXE201.SmartThrive.Domain.Entities;

public class SessionOffline : BaseEntity
{
    public string? Address { get; set; }

    public DateTime? Time { get; set; }

    public int? Duration { get; set; }

    public string? Attribute { get; set; }
    
    public virtual Session? Session { get; set; }
}
