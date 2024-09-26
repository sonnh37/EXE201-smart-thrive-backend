using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;

public class CategoryGetAllQuery : GetAllQuery
{
    public string? Name { get; set; }
}