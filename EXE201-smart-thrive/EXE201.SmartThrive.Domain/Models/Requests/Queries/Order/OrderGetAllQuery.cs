using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Order
{
    public class OrderGetAllQuery: PagedQuery
    {
        public Guid? PackageId { get; set; }

        public Guid? VoucherId { get; set; }

        public string? PaymentMethod { get; set; }

        public int? Amount { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }
    }
}
