using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.User
{
    public class UserGetAllQuery: PagedQuery
    {
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime? Dob { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string? Status { get; set; }

        public string? RoleName { get; set; }
    }
}
