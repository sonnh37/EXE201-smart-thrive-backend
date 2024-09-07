using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models;

public class SessionModel
{
    public SessionModel()
    {
    }

    public SessionModel(SessionModel payload)
    {
        Id = payload.Id;
        ModuleId = payload.ModuleId;
        Title = payload.Title;
        Document = payload.Document;
        SessionType = payload.SessionType;
        Description = payload.Description;
        SessionNumber = payload.SessionNumber;
        Detail = payload.Detail;
    }

    public Guid? Id { get; set; }
    public Guid? ModuleId { get; set; }
    public string? Title { get; set; }
    public string? Document { get; set; }
    public SessionType SessionType { get; set; }
    public int? SessionNumber { get; set; }
    public string? Description { get; set; }
    public object? Detail { get; set; }
}