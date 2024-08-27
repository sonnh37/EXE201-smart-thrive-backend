using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Utilities;

public class AppResponse
{
    public static ItemListResponse<TResult> SetItemListResponse<TResult>(List<TResult>? results)
        where TResult : BaseResult
    {
        var message = (results != null && results.Any()) ? Constant.Success : Constant.Fail;
        return new ItemListResponse<TResult>(message, results);
    }

    public static ItemResponse<TResult> SetItemResponse<TResult>(TResult? result)
        where TResult : BaseResult
    {
        var message = result != null ? Constant.Success : Constant.Fail;
        return new ItemResponse<TResult>(message, result);
    }
    
    public static MessageResponse SetMessageResponse(string message, bool isSuccess)
    {
        return new MessageResponse(isSuccess, message);
    }
}