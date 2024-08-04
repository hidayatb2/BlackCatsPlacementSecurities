using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Domain.Entities
{
    public class Employee : BaseEntity
    {

        public string Name { get; set; }= string.Empty;

        public string Address { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public DateOnly DateOfJoining { get; set; }

        public DateOnly? DateOfLeaving { get; set; }

        public long AadhaarNumber { get; set; }

        public long BankAccountNo { get; set; }

        public bool IsUniformFeePaid { get; set; }

        public bool IsDeleted { get; set; }

        public Guid ClientId { get; set; }


        #region Navigation Properties
        [ForeignKey(nameof(Id))]
        public Client Client { get; set; } = null!;
        #endregion

    }



}
