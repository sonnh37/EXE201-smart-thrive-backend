using EXE201.SmartThrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Models.Requests.Queries.Voucher
{
    public class VoucherGetAllQuery : PagedQuery
    {
        public VoucherType? VoucherType { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }
}
