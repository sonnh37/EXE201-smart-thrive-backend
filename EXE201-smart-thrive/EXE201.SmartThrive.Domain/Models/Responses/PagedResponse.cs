using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Responses;

public class PagedResponse<TResult> : MessageResponse where TResult : class
{
    public PagedResponse(string message, GetQueryableQuery pagedQuery, List<TResult>? results = null,
        int totalOrigin = 0)
        : base(results != null, message)
    {
        PageNumber = pagedQuery.PageNumber;
        PageSize = pagedQuery.PageSize;
        SortField = pagedQuery.SortField;
        SortOrder = pagedQuery.SortOrder;
        Results = results;
        TotalRecords = totalOrigin;
        TotalRecordsPerPage = results?.Count ?? 0;
        TotalPages = (int)Math.Ceiling(totalOrigin / (double)PageSize);
    }

    public List<TResult>? Results { get; }

    public int TotalPages { get; protected set; }

    public int TotalRecordsPerPage { get; protected set; }

    public int TotalRecords { get; protected set; }

    public int PageNumber { get; protected set; }

    public int PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public SortOrder? SortOrder { get; protected set; }
}