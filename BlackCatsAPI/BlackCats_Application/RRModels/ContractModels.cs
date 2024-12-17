using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.RRModels
{
    public class ContractRes
    {
        public DateOnly From { get; set; }

        public DateOnly To { get; set; }
    }
    public class ContractReq : ContractRes
    {
        public Guid ClientId { get; set; }
    }

    public class ContractUpdateReq : ContractRes
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

    }
}
