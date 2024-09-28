using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.ExceptionHandler;
using EXE201.SmartThrive.Domain.Exceptions;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using Serilog;

namespace EXE201.SmartThrive.Services.Base;

public abstract class BaseService
{
}

public abstract class BaseService<TEntity> : BaseService, IBaseService
    where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> _baseRepository;
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _baseRepository = _unitOfWork.GetRepositoryByEntity<TEntity>();
    }

    public async Task<BusinessResult> GetById<TResult>(Guid id) where TResult : BaseResult
    {
        try
        {
            var entity = await _baseRepository.GetById(id);
            var result = _mapper.Map<TResult>(entity);
            return ResponseHelper.CreateResult(result);
        }
        catch (Exception ex)
        {
            string errorMessage = $"An error {typeof(TResult).Name}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }

    public async Task<BusinessResult> GetAll<TResult>() where TResult : BaseResult
    {
        try
        {
            var entities = await _baseRepository.GetAll();
            var results = _mapper.Map<List<TResult>>(entities);
            return ResponseHelper.CreateResult(results);
        }
        catch (Exception ex)
        {
            string errorMessage = $"An error {typeof(TResult).Name}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }

    public async Task<BusinessResult> GetAll<TResult>(GetQueryableQuery x) where TResult : BaseResult
    {
        try
        {
            if (!x.IsPagination)
            {
                return await GetAll<TResult>();
            }

            var tuple = await _baseRepository.GetAll(x);
            var results = _mapper.Map<List<TResult>?>(tuple.Item1);

            return ResponseHelper.CreateResult((results, tuple.Item2), x);
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error {typeof(TResult).Name}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }


    #region Commands

    public async Task<BusinessResult> Update(UpdateCommand tRequest)
    {
        try
        {
            var entity = await _baseRepository.GetById(tRequest.Id);
            if (entity == null) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            _mapper.Map(tRequest, entity);
            SetBaseEntityUpdate(entity);
            _baseRepository.Update(entity);

            var saveChanges = await _unitOfWork.SaveChanges();
            return new BusinessResult(
                saveChanges ? Const.SUCCESS_CODE : Const.FAIL_CODE,
                saveChanges ? Const.SUCCESS_UPDATE_MSG : Const.FAIL_UPDATE_MSG
            );
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred while updating {typeof(TEntity).Name}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }

    public async Task<TEntity?> CreateEntity(CreateCommand tRequest)
    {
        var entity = _mapper.Map<TEntity>(tRequest);

        SetBaseEntityCreate(entity);
        _baseRepository.Add(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }

    public async Task<BusinessResult> Create(CreateCommand tRequest)
    {
        try
        {
            var entity = _mapper.Map<TEntity>(tRequest);

            SetBaseEntityCreate(entity);
            _baseRepository.Add(entity);

            var saveChanges = await _unitOfWork.SaveChanges();
            return new BusinessResult(
                saveChanges ? Const.SUCCESS_CODE : Const.FAIL_CODE,
                saveChanges ? Const.SUCCESS_CREATE_MSG : Const.FAIL_CREATE_MSG
            );
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred while creating {typeof(TEntity).Name}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }

    public async Task<BusinessResult> DeleteById(Guid id)
    {
        try
        {
            if (id == Guid.Empty) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            var entity = await DeleteEntity(id);

            return new BusinessResult(
                entity != null ? Const.SUCCESS_CODE : Const.FAIL_CODE,
                entity != null ? Const.SUCCESS_DELETE_MSG : Const.FAIL_DELETE_MSG
            );
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred while deleting {typeof(TEntity).Name} with ID {id}: {ex.Message}";
            Log.Error(ex, errorMessage);
            return ResponseHelper.CreateResult(errorMessage);
        }
    }

    private static void SetBaseEntityCreate(TEntity? entity)
    {
        if (entity == null) return;

        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdatedDate = DateTime.UtcNow;
        entity.IsDeleted = false;

        SetUserInformation(entity);
    }

    private static void SetBaseEntityUpdate(TEntity? entity)
    {
        if (entity == null) return;

        entity.UpdatedDate = DateTime.UtcNow;
        SetUserInformation(entity);
    }

    private static void SetUserInformation(TEntity entity)
    {
        var user = InformationUser.User;

        if (user == null) return;

        entity.UpdatedBy = user.Email;
        if (entity.CreatedDate == default)
        {
            entity.CreatedBy = user.Email;
        }
    }

    private async Task<TEntity?> DeleteEntity(Guid id)
    {
        var entity = await _baseRepository.GetById(id);
        if (entity == null) return null;

        _baseRepository.Delete(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }

    #endregion
}