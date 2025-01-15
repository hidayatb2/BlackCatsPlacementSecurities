using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.RRModels
{
    public class ContractResponse
    {
        public DateOnly From { get; set; }

        public DateOnly To { get; set; }
    }
    public class ContractRequest : ContractResponse
    {
        public Guid ClientId { get; set; }
    }

    public class ContractUpdateRequest : ContractResponse
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

    }
}
