using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;

namespace EXE201.SmartThrive.Domain.Contracts.Services;

public interface IBlogService : IBaseService
{
    Task<PagedResponse<BlogResult>> GetAllFiltered(BlogGetAllQuery query);
}