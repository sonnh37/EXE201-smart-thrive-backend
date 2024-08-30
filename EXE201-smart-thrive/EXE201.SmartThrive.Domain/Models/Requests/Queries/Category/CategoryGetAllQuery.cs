namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;

public class CategoryGetAllQuery : PagedQuery
{
    public string? Name { get; set; }
}