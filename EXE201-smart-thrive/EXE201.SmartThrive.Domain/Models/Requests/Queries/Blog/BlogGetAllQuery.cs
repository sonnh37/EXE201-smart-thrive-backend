using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Blog
{
    public class BlogGetAllQuery : PagedQuery
    {
        public Guid? UserId { get; set; }

        public string? Title { get; set; }

    }
}
