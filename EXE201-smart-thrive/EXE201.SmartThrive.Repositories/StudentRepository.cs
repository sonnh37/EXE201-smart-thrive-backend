using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Utilities.Sorts;
using EXE201.SmartThrive.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXE201.SmartThrive.Data.Context;

namespace EXE201.SmartThrive.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(STDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(List<Student>, int)> GetAllFiltered(StudentGetAllQuery query)
        {
            var queryable = base.GetQueryable();

            // filter
            queryable = ApplyFilter.Student(queryable, query);

            var totalOrigin = queryable.Count();

            // sort & pagination
            var results = await base.ApplySortingAndPaging(queryable, query);

            return (results, totalOrigin);
        }
    }
}