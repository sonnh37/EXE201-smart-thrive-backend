namespace EXE201.SmartThrive.Domain.Models.Results;

public class DayInWeekResult : BaseResult
{
    public Guid? CourseId { get; set; }

    public bool Monday { get; set; }

    public bool Thursday { get; set; }

    public bool Tuesday { get; set; }

    public bool Wednesday { get; set; }

    public bool Friday { get; set; }

    public bool Saturday { get; set; }

    public bool Sunday { get; set; }

    public CourseResult? Course { get; set; }
}