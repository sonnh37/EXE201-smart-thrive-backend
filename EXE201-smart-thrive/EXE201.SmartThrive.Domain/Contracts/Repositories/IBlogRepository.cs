using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;

namespace EXE201.SmartThrive.Domain.Contracts.Repositories;

public interface IBlogRepository : IBaseRepository<Blog>
{
    Task<(List<Blog>, int)> GetAllFiltered(BlogGetAllQuery query);
}