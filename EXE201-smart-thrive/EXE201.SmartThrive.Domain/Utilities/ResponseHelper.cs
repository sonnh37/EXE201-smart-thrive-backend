using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Utilities;

public static class ResponseHelper
{
    public static ItemListResponse<TResult> CreateItemList<TResult>(List<TResult>? results)
        where TResult : BaseResult
    {
        if (results == null) return new ItemListResponse<TResult>(ConstantHelper.Fail, results);

        if (!results.Any()) return new ItemListResponse<TResult>(ConstantHelper.NotFound, results);

        return new ItemListResponse<TResult>(ConstantHelper.Success, results);
    }

    public static PagedResponse<TResult> CreatePaged<TResult>((List<TResult>?, int?) item, GetQueryableQuery pagedQuery)
        where TResult : BaseResult
    {
        if (item.Item1 == null) return new PagedResponse<TResult>(ConstantHelper.Fail, pagedQuery, item.Item1);

        if (item.Item1.Count == 0) return new PagedResponse<TResult>(ConstantHelper.NotFound, pagedQuery, item.Item1);

        return new PagedResponse<TResult>(ConstantHelper.Success, pagedQuery, item.Item1, item.Item2);
    }

    public static ItemResponse<TResult> CreateItem<TResult>(TResult? result)
        where TResult : BaseResult
    {
        var message = result != null ? ConstantHelper.Success : ConstantHelper.Fail;
        return new ItemResponse<TResult>(message, result);
    }

    public static MessageResponse CreateMessage(string message, bool isSuccess)
    {
        return new MessageResponse(isSuccess, message);
    }
}