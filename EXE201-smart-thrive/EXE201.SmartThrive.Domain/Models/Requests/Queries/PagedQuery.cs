using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries;

public abstract class PagedQuery : BaseQuery
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? SortField { get; set; }

    public int? SortOrder { get; set; }
}