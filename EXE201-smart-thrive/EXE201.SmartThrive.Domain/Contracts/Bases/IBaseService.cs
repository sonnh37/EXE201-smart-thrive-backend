using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Bases;

public interface IBaseService
{
    Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : BaseResult;

    Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;

    Task<MessageResponse> Create(CreateCommand tRequest);
    
    Task<MessageResponse> Update(UpdateCommand tRequest);

    Task<MessageResponse> DeleteById(Guid id);
}