﻿using EXE201.SmartThrive.Data.Context;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Repositories.Base;

namespace EXE201.SmartThrive.Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(STDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<(List<Feedback>, int)> GetAllFiltered(FeedbackGetAllQuery query)
        {
            var queryable = base.GetQueryable();

            // filter
            queryable = ApplyFilter.Feedback(queryable, query);
         
            var totalOrigin = queryable.Count();

            // sort & pagination
            var results = await base.ApplySortingAndPaging(queryable, query);

            return (results, totalOrigin);
        }
    }
}