using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Module;

public class ModuleGetAllQuery : GetAllQuery
{
    public Guid? CourseId { get; set; }
    public string? Name { get; set; }
}