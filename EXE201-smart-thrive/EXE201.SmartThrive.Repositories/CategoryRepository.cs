using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Category;
using EXE201.SmartThrive.Domain.Utilities.Sorts;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(List<Category>, int)> GetAllFiltered(CategoryGetAllQuery query)
    {
        var queryable = base.GetQueryable();
        
        // filter
        queryable = ApplyFilter.Category(queryable, query);

        var totalOrigin = queryable.Count();
        
        // sort & pagination
        var results = await base.ApplySortingAndPaging(queryable, query);
        
        return (results, totalOrigin);
    }
    
    
}