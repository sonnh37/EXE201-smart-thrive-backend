namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class SessionSelfLearn : BaseEntity
{
    public int? SessionNumber { get; set; }
    
    public string? VideoURL { get; set; }

    public bool IsComplete { get; set; }
    
    public virtual Session? Session { get; set; }
}
