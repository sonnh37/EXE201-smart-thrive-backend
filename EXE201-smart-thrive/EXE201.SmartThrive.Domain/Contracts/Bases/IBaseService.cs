using EXE201.SmartThrive.Domain.Models.Requests;
using EXE201.SmartThrive.Domain.Models.Requests.Base;
using EXE201.SmartThrive.Domain.Models.Responses;

namespace EXE201.SmartThrive.Domain.Contracts.Bases;

public interface IBaseService
{
    Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : MessageResponse;

    Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : MessageResponse;

    Task<MessageResponse> Create<TView>(BaseRequest tRequest) where TView : BaseRequest;
    
    Task<MessageResponse> Update<TView>(BaseRequest tRequest) where TView : BaseRequest;

    Task<MessageResponse> DeleteById<TView>(Guid id) where TView : BaseRequest;
}