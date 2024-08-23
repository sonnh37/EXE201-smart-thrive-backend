namespace EXE201.SmartThrive.Repositories.Data.Entities;

public class Blog : BaseEntity
{
    public Guid? UserId { get; set; }

    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
    
    public string? Status { get; set; }
    
    public string? BackgroundImage { get; set; }
    
    public virtual User? User { get; set; }
    
}