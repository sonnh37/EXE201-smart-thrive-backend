using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Responses;

public class PagedResponse<TResult> where TResult : class
{
    public PagedResponse(GetQueryableQuery pagedQuery, List<TResult>? results = null, int? totalOrigin = null)
        
    {
        PageNumber = totalOrigin != null ? pagedQuery.PageNumber : null;
        PageSize = totalOrigin != null ? pagedQuery.PageSize : null;
        SortField = totalOrigin != null ? pagedQuery.SortField : null;
        SortOrder = totalOrigin != null ? pagedQuery.SortOrder : null;
        Results = results;
        TotalRecords = totalOrigin ?? results?.Count;
        TotalRecordsPerPage = totalOrigin != null ? results?.Count : null;
        TotalPages = totalOrigin != null
            ? (int)Math.Ceiling((decimal)(totalOrigin / (double)pagedQuery.PageSize))
            : null;
    }

    public List<TResult>? Results { get; }

    public int? TotalPages { get; protected set; }

    public int? TotalRecordsPerPage { get; protected set; }

    public int? TotalRecords { get; protected set; }

    public int? PageNumber { get; protected set; }

    public int? PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public SortOrder? SortOrder { get; protected set; }
}