using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models
{
    public class SessionComming
    {
        public string? CourseName { get; set; }
        public string? SessionTitle { get; set; }
        public string? TeacherName { get; set; }
        public SessionType? SessionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
