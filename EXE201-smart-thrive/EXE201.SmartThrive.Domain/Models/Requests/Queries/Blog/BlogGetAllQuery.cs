using EXE201.SmartThrive.Domain.Models.Requests.Queries.Base;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog;

public class BlogGetAllQuery : GetAllQuery
{
    public Guid? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public List<bool?>? IsActive { get; set; }

    public string? BackgroundImage { get; set; }
}