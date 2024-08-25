namespace EXE201.SmartThrive.Domain.Models.Results;

public class OrderDetailResult : BaseResult
{
    public Guid? OrderId { get; set; }

    public Guid? CourseId { get; set; }

    public decimal? Price { get; set; }

    public decimal? PriceDiscount { get; set; }

    public string? Status { get; set; }

    public OrderResult? Order { get; set; }
}