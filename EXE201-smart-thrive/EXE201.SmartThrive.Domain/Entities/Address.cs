namespace EXE201.SmartThrive.Domain.Entities;

public class Address : BaseEntity
{
    public Guid? ProviderId { get; set; }
    
    public string? City { get; set; }
    
    // quận, huyện
    public string? District { get; set; }
    
    // xã, phường, thị trấn
    public string? Town { get; set; }
    
    // đường
    public string? Street { get; set; }
    
    public string? BuildingNumber { get; set; }
    
    public virtual Provider? Provider { get; set; }
}