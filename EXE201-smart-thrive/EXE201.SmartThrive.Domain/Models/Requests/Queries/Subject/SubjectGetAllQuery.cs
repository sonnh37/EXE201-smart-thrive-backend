using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;

public class SubjectGetAllQuery : GetAllQuery
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }
}