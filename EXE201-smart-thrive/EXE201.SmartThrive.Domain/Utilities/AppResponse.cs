using EXE201.SmartThrive.Domain.Models.Requests.Queries;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Utilities;

public static class AppResponse
{
    public static ItemListResponse<TResult> CreateItemList<TResult>(List<TResult>? results)
        where TResult : BaseResult
    {
        if (results == null)
        {
            return new ItemListResponse<TResult>(Constant.Fail, results);
        }

        if (!results.Any())
        {
            return new ItemListResponse<TResult>(Constant.NotFound, results);
        }

        return new ItemListResponse<TResult>(Constant.Success, results);
    }

    public static PaginatedResponse<TResult> CreatePaginated<TResult>((List<TResult>?, int) item, PagedQuery pagedQuery)
        where TResult : BaseResult
    {
        if (item.Item1 == null)
        {
            return new PaginatedResponse<TResult>(Constant.Fail, pagedQuery, item.Item1);
        }

        if (!item.Item1.Any())
        {
            return new PaginatedResponse<TResult>(Constant.NotFound, pagedQuery, item.Item1);
        }

        return new PaginatedResponse<TResult>(Constant.Success, pagedQuery, item.Item1, item.Item2);
    }

    public static ItemResponse<TResult> CreateItem<TResult>(TResult? result)
        where TResult : BaseResult
    {
        var message = result != null ? Constant.Success : Constant.Fail;
        return new ItemResponse<TResult>(message, result);
    }

    public static MessageResponse CreateMessage(string message, bool isSuccess)
    {
        return new MessageResponse(isSuccess, message);
    }
}