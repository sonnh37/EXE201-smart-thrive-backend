namespace EXE201.SmartThrive.Domain.Models.Results;

public class CategoryResult : BaseResult
{
    public string? Name { get; set; }

    public List<SubjectResult>? Subjects { get; set; }
}