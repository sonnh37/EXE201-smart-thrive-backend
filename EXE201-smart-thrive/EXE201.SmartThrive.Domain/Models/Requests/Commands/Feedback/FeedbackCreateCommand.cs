using EXE201.SmartThrive.Domain.Models.Requests.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Commands.Feedback
{
    public class FeedbackCreateCommand : CreateCommand
    {
        public Guid? StudentId { get; set; }

        public Guid? CourseId { get; set; }

        public string? Description { get; set; }

        public int? Rating { get; set; }

    }
}
