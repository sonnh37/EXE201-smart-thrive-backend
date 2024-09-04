using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Module
{
    public class ModuleGetAllQuery : PagedQuery
    {
        public Guid? CourseId { get; set; }
        public string? Name { get; set; }

    }
}
