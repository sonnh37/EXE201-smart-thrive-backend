using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback;

public class FeedbackGetAllQuery : GetAllQuery
{
    public Guid? StudentId { get; set; }

    public Guid? CourseId { get; set; }
    public int? Rating { get; set; }
}