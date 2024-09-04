using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Blog;

public class BlogCreateCommand : CreateCommand
{
    public Guid? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? Status { get; set; }

    public string? BackgroundImage { get; set; }
}