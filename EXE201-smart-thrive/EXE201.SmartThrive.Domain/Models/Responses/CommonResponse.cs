using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Responses;

public class LoginResponse
{
    public string? Token { get; set; }
    public string? Expiration { get; set; }

    public LoginResponse()
    {
    }

    public LoginResponse(string? token, string? expiration)
    {
        Token = token;
        Expiration = expiration;
    }
}

public class ResultResponse<TResult> where TResult : class
{

    public TResult? Result { get; set; }

    public ResultResponse()
    {
    }

    public ResultResponse(TResult? result = null)
    {
        Result = result;
    }
}

public class ResultsResponse<TResult> where TResult : class
{
    public List<TResult>? Results { get; set; }

    public int TotalRecords { get; set; }

    public ResultsResponse()
    {
    }

    public ResultsResponse(List<TResult>? results = null)
    {
        Results = results;
        TotalRecords = results?.Count ?? 0;
    }
}

public class PagedResponse<TResult> where TResult : class
{
    public List<TResult>? Results { get; }

    public int? TotalPages { get; protected set; }

    public int? TotalRecordsPerPage { get; protected set; }

    public int? TotalRecords { get; protected set; }

    public int? PageNumber { get; protected set; }

    public int? PageSize { get; protected set; }

    public string? SortField { get; protected set; }

    public SortOrder? SortOrder { get; protected set; }

    public PagedResponse()
    {
    }

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
}