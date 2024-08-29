
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Subject
{
    public class FeedbackGetAllQuery : PagedQuery
    {
        public Guid? StudentId { get; set; }

        public Guid? CourseId { get; set; }

        public int? Rating { get; set; }
    }
}
