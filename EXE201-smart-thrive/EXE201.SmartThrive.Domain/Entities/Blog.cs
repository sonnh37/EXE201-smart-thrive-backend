using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Entities;

public class Blog : BaseEntity
{
    public Guid? UserId { get; set; }

    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
    
    public BlogStatus? Status { get; set; }
    
    public string? BackgroundImage { get; set; }
    
    public virtual User? User { get; set; }
    
}