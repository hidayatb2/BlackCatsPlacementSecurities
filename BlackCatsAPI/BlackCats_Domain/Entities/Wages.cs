using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;

        #endregion



    }
}
