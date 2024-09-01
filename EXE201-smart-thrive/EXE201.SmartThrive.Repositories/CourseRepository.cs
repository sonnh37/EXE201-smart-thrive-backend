using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(STDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(List<Course>, int)> GetAllFiltered(CourseGetAllQuery query)
    {
        var queryable = GetQueryable();

        // filter
        queryable = ApplyFilter.Course(queryable, query);

        var totalOrigin = queryable.Count();

        // sort & pagination
        var results = await ApplySortingAndPaging(queryable, query);

        return (results, totalOrigin);
    }
}