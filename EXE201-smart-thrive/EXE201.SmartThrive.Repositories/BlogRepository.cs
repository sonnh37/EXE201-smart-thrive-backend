using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Repositories.Base;


namespace EXE201.SmartThrive.Repositories
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(STDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(List<Blog>, int)> GetAllFiltered(BlogGetAllQuery query)
        {
            var queryable = base.GetQueryable();

            // filter
            queryable = ApplyFilter.Blog(queryable, query);

            var totalOrigin = queryable.Count();

            // sort & pagination
            var results = await base.ApplySortingAndPaging(queryable, query);

            return (results, totalOrigin);
        }
    }
}
