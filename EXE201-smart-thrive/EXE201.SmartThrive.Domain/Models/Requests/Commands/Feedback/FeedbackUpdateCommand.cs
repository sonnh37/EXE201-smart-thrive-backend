using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Feedback;

public class FeedbackUpdateCommand : UpdateCommand
{
    public Guid? StudentId { get; set; }

    public Guid? CourseId { get; set; }

    public string? Description { get; set; }

    public int? Rating { get; set; }
}