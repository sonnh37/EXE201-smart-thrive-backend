using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXE201.SmartThrive.Domain.Enums;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Student
{
    public class StudentGetAllQuery : PagedQuery
    {
        public Guid? UserId { get; set; }

        public string? StudentName { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? Dob { get; set; }

        public string? Phone { get; set; }

        public UserStatus? Status { get; set; }
    }
}