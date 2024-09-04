

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Feedback
{
    public class FeedbackGetAllQuery : PagedQuery
    {
        public Guid? StudentId { get; set; }

        public Guid? CourseId { get; set; }
        public int? Rating { get; set; }

    }
}
