using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Bases;

public interface IBaseService
{
    Task<BusinessResult> GetAll<TResult>() where TResult : BaseResult;

    Task<BusinessResult> GetAll<TResult>(GetQueryableQuery query) where TResult : BaseResult;

    Task<BusinessResult> GetById<TResult>(Guid id) where TResult : BaseResult;

    Task<BusinessResult> Create(CreateCommand tRequest);

    Task<BusinessResult> Update(UpdateCommand tRequest);

    Task<BusinessResult> DeleteById(Guid id);
    Task<BusinessResult> RemoveById(Guid id);
}