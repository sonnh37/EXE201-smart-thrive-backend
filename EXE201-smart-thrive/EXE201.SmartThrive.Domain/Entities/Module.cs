namespace EXE201.SmartThrive.Domain.Entities;

public class Module : BaseEntity
{
    public Guid? CourseId { get; set; }
    
    public int? ModuleNumber { get; set; }

    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public virtual Course? Course { get; set; }
    
    public virtual ICollection<Session>? Sessions { get; set; }
}