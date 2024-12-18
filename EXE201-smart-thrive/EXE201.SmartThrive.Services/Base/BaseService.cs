﻿using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
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
            List<TResult>? results;
            int totalItems = 0;

            if (!x.IsPagination)
            {
                var allData = await _baseRepository.GetAll(x);
                results = _mapper.Map<List<TResult>?>(allData);
                return ResponseHelper.CreateResult(results);
            }

            var tuple = await _baseRepository.GetPaged(x);
            results = _mapper.Map<List<TResult>?>(tuple.Item1);
            totalItems = tuple.Item2;

            return ResponseHelper.CreateResult((results, totalItems), x);
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred in {typeof(TResult).Name}: {ex.Message}";
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
                saveChanges ? Const.SUCCESS_CREATE_MSG : Const.FAIL_CREATE_MSG,
                saveChanges ? entity : null
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
    
    public async Task<BusinessResult> RemoveById(Guid id)
    {
        try
        {
            if (id == Guid.Empty) return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

            var entity = await RemoveEntity(id);

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

    protected static void SetBaseEntityCreate(TEntity? entity)
    {
        if (entity == null) return;

        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdatedDate = DateTime.UtcNow;
        entity.IsDeleted = false;

        var user = InformationUser.User;

        if (user == null) return;

        entity.UpdatedBy = user.Email;
        entity.CreatedBy = user.Email;
    }

    protected static void SetBaseEntityUpdate(TEntity? entity)
    {
        if (entity == null) return;

        entity.UpdatedDate = DateTime.UtcNow;
        var user = InformationUser.User;

        if (user == null) return;

        entity.UpdatedBy = user.Email;
    }

    private async Task<TEntity?> DeleteEntity(Guid id)
    {
        var entity = await _baseRepository.GetById(id);
        if (entity == null) return null;

        _baseRepository.Delete(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }
    
    private async Task<TEntity?> RemoveEntity(Guid id)
    {
        var entity = await _baseRepository.GetById(id);
        if (entity == null) return null;

        _baseRepository.Remove(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }

    #endregion
}