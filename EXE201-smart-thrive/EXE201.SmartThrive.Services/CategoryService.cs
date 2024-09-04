using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class CategoryService : BaseService<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _categoryRepository = _unitOfWork.CategoryRepository;
    }

    public async Task<PaginatedResponse<CategoryResult>> GetAllFiltered(CategoryGetAllQuery query)
    {
        var categorysWithTotal = await _categoryRepository.GetAllFiltered(query);
        var categorysResult = _mapper.Map<List<CategoryResult>>(categorysWithTotal.Item1);
        var categorysResultWithTotal = (categorysResult, categorysWithTotal.Item2);

        return AppResponse.CreatePaginated(categorysResultWithTotal, query);
    }
}