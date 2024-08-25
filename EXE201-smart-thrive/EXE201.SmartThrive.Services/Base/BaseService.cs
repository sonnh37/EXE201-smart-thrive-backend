using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;

namespace EXE201.SmartThrive.Services.Base;

public abstract class BaseService
{
}

public abstract class BaseService<TEntity> : BaseService, IBaseService
    where TEntity : BaseEntity
{
    protected readonly IBaseRepository<TEntity> _baseRepository;
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _baseRepository = _unitOfWork.GetRepositoryByEntity<TEntity>();
    }

    public async Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult
    {
        var entity = await _baseRepository.GetById(id);

        var result = _mapper.Map<TResult>(entity);
        var message = result != null ? Constant.Success : Constant.Fail;
        var msgResult = AppResponse.SetItemResponse(message, result);

        return msgResult;
    }

    public async Task<MessageResponse> Update(UpdateCommand tRequest)
    {
        var entity = await _baseRepository.GetById(tRequest.Id);
        if (entity == null) return AppResponse.SetMessageResponse(Constant.NotFound, false);
        _mapper.Map(tRequest, entity);
        SetBaseEntityUpdate(entity);
        _baseRepository.Update(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        var message = saveChanges ? Constant.Success : Constant.Fail;
        var msg = AppResponse.SetMessageResponse(message, saveChanges);
        return msg;
    }

    public async Task<MessageResponse> Create(CreateCommand tRequest)
    {
        var entity = _mapper.Map<TEntity>(tRequest);
        if (entity == null) return AppResponse.SetMessageResponse(Constant.NotFound, false);
        SetBaseEntityCreate(entity);
        _baseRepository.Add(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        var message = saveChanges ? Constant.Success : Constant.Fail;
        var msg = AppResponse.SetMessageResponse(message, saveChanges);
        return msg;
    }

    public async Task<MessageResponse> DeleteById(Guid id)
    {
        if (id == Guid.Empty) return AppResponse.SetMessageResponse(Constant.NotFound, false);

        var entity = await DeleteEntity(id);

        var message = entity != null ? Constant.Success : Constant.Fail;
        var msg = AppResponse.SetMessageResponse(message, entity != null);

        return msg;
    }

    public async Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : BaseResult
    {
        var entities = await _baseRepository.GetAll();

        var results = _mapper.Map<List<TResult>>(entities);
        var message = (results != null && results.Any()) ? Constant.Success : Constant.Fail;
        var msgResults = AppResponse.SetItemListResponse(message, results);

        return msgResults;
    }

    private TEntity? SetBaseEntityCreate(TEntity? entity)
    {
        var user = InformationUser.User;
        entity.Id = Guid.NewGuid();
        entity.CreatedDate = DateTime.Now;
        entity.UpdatedDate = DateTime.Now;
        entity.IsDeleted = false;

        if (user == null) return entity;

        entity.CreatedBy = user.Email;
        entity.UpdatedBy = user.Email;

        return entity;
    }

    private TEntity? SetBaseEntityUpdate(TEntity? entity)
    {
        var user = InformationUser.User;
        entity.UpdatedDate = DateTime.Now;

        if (user == null) return entity;

        entity.UpdatedBy = user.Email;

        return entity;
    }

    private async Task<TEntity?> DeleteEntity(Guid id)
    {
        TEntity? entity;
        entity = await _baseRepository.GetById(id);
        if (entity == null) return null;

        _baseRepository.Delete(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }
}