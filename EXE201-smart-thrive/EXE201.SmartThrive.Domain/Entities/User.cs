namespace EXE201.SmartThrive.Domain.Entities;

public class User : BaseEntity
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public string? RoleName { get; set; }
    
    public virtual ICollection<Blog>? Blogs { get; set; }

    public virtual Provider? Provider { get; set; }

    public virtual ICollection<Student>? Students { get; set; }
}