using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Services
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _blogRepository = unitOfWork.BlogRepository;
        }

        public async Task<PaginatedResponse<BlogResult>> GetAllFiltered(BlogGetAllQuery query)
        {
            var blogsWithTotal = await _blogRepository.GetAllFiltered(query);
            var blogsResult = _mapper.Map<List<BlogResult>>(blogsWithTotal.Item1);
            var blogsResultWithTotal = (blogsResult, blogsWithTotal.Item2);

            return AppResponse.CreatePaginated(blogsResultWithTotal, query);
        }
    }
}
