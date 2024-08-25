using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Utilities;

public class AppResponse
{
    public static ItemListResponse<TResult> SetItemListResponse<TResult>(string message, List<TResult>? results)
        where TResult : BaseResult
    {
        return new ItemListResponse<TResult>(message, results);
    }

    public static ItemResponse<TResult> SetItemResponse<TResult>(string message, TResult? result)
        where TResult : BaseResult
    {
        return new ItemResponse<TResult>(message, result);
    }
    
    public static MessageResponse SetMessageResponse(string message, bool isSuccess)
    {
        return new MessageResponse(isSuccess, message);
    }
}