using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class SubjectService : BaseService<Subject>, ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _subjectRepository = _unitOfWork.SubjectRepository;
    }

    public async Task<PaginatedResponse<SubjectResult>> GetAllFiltered(SubjectGetAllQuery query)
    {
        var subjectsWithTotal = await _subjectRepository.GetAllFiltered(query);
        var subjectsResult = _mapper.Map<List<SubjectResult>>(subjectsWithTotal.Item1);
        var subjectsResultWithTotal = (subjectsResult, subjectsWithTotal.Item2);

        return AppResponse.CreatePaginated(subjectsResultWithTotal, query);
    }
}