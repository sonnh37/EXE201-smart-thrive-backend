namespace EXE201.SmartThrive.Domain.Models.Responses;

public class PaginatedListResponse<TResult> : MessageResponse where TResult : class
{
    public List<TResult>? Results { get; }

    public int TotalPages { get; protected set; }

    public int TotalRecordsPerPage { get; protected set; }

    public int TotalRecords { get; protected set; }

    public int PageNumber { get; protected set; }

    public int PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public int? SortOrder { get; protected set; }

    public PaginatedListResponse(string message, List<TResult>? results = null, long totalOrigin = 0, int pageNumber = 1, int pageSize = 1, string? sortField = null, int? sortOrder = null) : base(results != null, message)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SortField = sortField;
        SortOrder = sortOrder;
        Results = results;
        TotalRecords = (int) totalOrigin;
        TotalRecordsPerPage = results != null ? results.Count : 0;
        TotalPages = (int)Math.Ceiling(totalOrigin / (double)PageSize);
    }
}