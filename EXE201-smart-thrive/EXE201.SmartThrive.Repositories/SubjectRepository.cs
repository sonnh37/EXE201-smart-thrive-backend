using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Utilities.Sorts;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(List<Subject>, int)> GetAllFiltered(SubjectGetAllQuery query)
    {
        var queryable = base.GetQueryable();
        
        // filter
        queryable = ApplyFilter.Subject(queryable, query);

        var totalOrigin = queryable.Count();
        
        // sort & pagination
        var results = await base.ApplySortingAndPaging(queryable, query);
        
        return (results, totalOrigin);
    }
    
    
}