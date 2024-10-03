namespace EXE201.SmartThrive.Domain.Entities;

public class SessionOffline : BaseEntity
{
    public Guid? SessionId { get; set; }

    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public int? Duration { get; set; } // phut

    public virtual Session? Session { get; set; }
}