using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Queries.Student;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;

namespace EXE201.SmartThrive.Services;

public class StudentService : BaseService<Student>, IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _studentRepository = _unitOfWork.StudentRepository;
    }

    public async Task<PaginatedResponse<StudentResult>> GetAllFiltered(StudentGetAllQuery query)
    {
        var studentsWithTotal = await _studentRepository.GetAllFiltered(query);
        var studentsResult = _mapper.Map<List<StudentResult>>(studentsWithTotal.Item1);
        var studentsResultWithTotal = (studentsResult, studentsWithTotal.Item2);

        return AppResponse.CreatePaginated(studentsResultWithTotal, query);
    }
}