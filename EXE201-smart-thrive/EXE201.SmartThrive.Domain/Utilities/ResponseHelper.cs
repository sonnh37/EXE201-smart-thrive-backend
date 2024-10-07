using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Utilities;

public static class ResponseHelper
{
    public static BusinessResult CreateResult<TResult>(TResult? result)
        where TResult : BaseResult
    {
        if (result == null)
        {
            return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, null);
        }

        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_READ_MSG, result);
    }

    public static BusinessResult CreateResult<TResult>(List<TResult>? results)
        where TResult : BaseResult
    {
        if (results == null || !results.Any())
        {
            var response = new ResultsResponse<TResult>(results);
            return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, response);
        }

        var res = new ResultsResponse<TResult>(results);
        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_READ_MSG, res);
    }

    public static BusinessResult CreateResult<TResult>((List<TResult>? List, int? TotalCount) item,
        GetQueryableQuery pagedQuery)
        where TResult : BaseResult
    {
        if (item.List == null || !item.List.Any())
        {
            var response = new PagedResponse<TResult>(pagedQuery);
            return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, response);
        }

        var res = new PagedResponse<TResult>(pagedQuery, item.List, item.TotalCount);
        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_READ_MSG, res);
    }

    public static BusinessResult CreateResult(string e)
    {
        return new BusinessResult(Const.ERROR_EXCEPTION_CODE, e);
    }

    public static BusinessResult CreateResult(string? token, string? expiration, string? msg = null)
    {
        if (token == null && expiration == null && msg != null)
        {
            var response = new LoginResponse(null, null);
            return new BusinessResult(Const.NOT_FOUND_CODE, msg, response);
        }

        var res = new LoginResponse(token, expiration);
        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_LOGIN_MSG, res);
    }
}