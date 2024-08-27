namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject;

public class SubjectGetAllQuery : PagedQuery
{
    public string? Name { get; set; }

    public Guid? CategoryId { get; set; }
}