using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Domain.Entities
{
    public class Wages:BaseEntity
    {
        public int DailyWages { get; set; }

        public int NoOfWorkingDays { get; set; }

        public DateOnly WageMonth { get; set; }

        public int PFDeduction { get; set; }

        public int ESICDeduction { get; set; }

        public Guid EmployeeId { get; set; }



        #region Navigation Properties

        [ForeignKey(nameof(Id))]
        public Employee Employee { get; set; } = null!;

        #endregion



    }
}
