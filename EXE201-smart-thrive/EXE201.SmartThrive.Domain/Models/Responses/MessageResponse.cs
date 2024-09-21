namespace EXE201.SmartThrive.Domain.Models.Responses;

// public class MessageResponse
// {
//     public MessageResponse(bool isSuccess, string message)
//     {
//         IsSuccess = isSuccess;
//         Message = message;
//     }
//
//     public bool IsSuccess { get; protected set; }
//     public string Message { get; protected set; }
// }

// public class LoginResponse<TResult> : MessageResponse where TResult : class
// {
//     public LoginResponse(string message, TResult result, string token, string expiration) : base(result != null,
//         message)
//     {
//         Result = result;
//         Token = token;
//         Expiration = expiration;
//     }
//
//     public TResult Result { get; }
//     public string Token { get; }
//     public string Expiration { get; }
// }

public class ItemResponse<TResult>  where TResult : class
{

    public TResult? Result { get; }
    public ItemResponse(TResult? result = null)
    {
        Result = result;
    }
}

public class ItemListResponse<TResult> where TResult : class
{
    public ItemListResponse(List<TResult>? results = null)
    {
        Results = results;
        TotalRecords = results != null ? results.Count : 0;
    }

    public List<TResult>? Results { get; }

    public int TotalRecords { get; protected set; }
}