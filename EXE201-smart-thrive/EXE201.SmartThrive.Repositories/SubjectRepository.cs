using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories;

public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Subject>> GetAllFilter(SubjectGetAllQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryable = GetQueryable();

        // Apply base filtering: not deleted
        //queryable = queryable.Where(entity => !entity.IsDeleted);


        // Additional filtering based on SubjectIds (exclude these IDs if given)

        // Include related EventXSubjects

        // Execute the query asynchronously
        var results = await queryable.ToListAsync(cancellationToken);

        return results;
    }
}