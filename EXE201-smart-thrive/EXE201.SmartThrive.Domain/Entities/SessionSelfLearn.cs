namespace EXE201.SmartThrive.Domain.Entities;

public class SessionSelfLearn : BaseEntity
{
    public Guid? SessionId { get; set; }

    public int? SessionNumber { get; set; }

    public string? VideoUrl { get; set; }

    public bool IsComplete { get; set; }

    public virtual Session? Session { get; set; }
}