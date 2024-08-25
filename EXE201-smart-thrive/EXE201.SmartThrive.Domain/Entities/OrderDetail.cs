namespace EXE201.SmartThrive.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public Guid? OrderId { get; set; }
    
    public Guid? CourseId { get; set; }

    public decimal? Price { get; set; }

    public decimal? PriceDiscount { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }
}