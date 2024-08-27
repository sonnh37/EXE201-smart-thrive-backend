namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

public class BaseQuery
{
    public Guid Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }
}