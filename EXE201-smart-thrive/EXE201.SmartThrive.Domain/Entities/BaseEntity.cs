using System.ComponentModel.DataAnnotations;

namespace EXE201.SmartThrive.Domain.Entities;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}