using AutoMapper;
using EXE201.SmartThrive.API.HandleException;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class BlogService : BaseService<Blog>, IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _blogRepository = unitOfWork.BlogRepository;
    }
}