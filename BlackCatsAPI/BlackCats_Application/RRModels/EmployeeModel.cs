using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.RRModels
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public DateOnly DateOfJoining { get; set; }

        public DateOnly? DateOfLeaving { get; set; }

        public long AadhaarNumber { get; set; }

        public long BankAccountNo { get; set; }

        public bool IsUniformFeePaid { get; set; }

        public Guid ClientId { get; set; }
    }

    public class EmployeeResponse:EmployeeRequest
    {

    }

    public class EmployeeUpdateRequest:EmployeeRequest
    {
        public Guid Id { get; set; }

    }
    public class EmployeeUpdateResponse:EmployeeResponse
    {

    }
}
