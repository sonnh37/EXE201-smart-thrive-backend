using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;

public class SubjectCreateCommand : CreateCommand
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }
}