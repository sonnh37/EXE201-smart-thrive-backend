using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Course;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class CourseService : BaseService<Course>, ICourseService
{
    private readonly ICourseRepository _subjectRepository;

    public CourseService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _subjectRepository = _unitOfWork.CourseRepository;
    }

    public async Task<PaginatedResponse<CourseResult>> GetAllFiltered(CourseGetAllQuery query)
    {
        var subjectsWithTotal = await _subjectRepository.GetAllFiltered(query);
        var subjectsResult = _mapper.Map<List<CourseResult>>(subjectsWithTotal.Item1);
        var subjectsResultWithTotal = (subjectsResult, subjectsWithTotal.Item2);

        return AppResponse.CreatePaginated(subjectsResultWithTotal, query);
    }

}