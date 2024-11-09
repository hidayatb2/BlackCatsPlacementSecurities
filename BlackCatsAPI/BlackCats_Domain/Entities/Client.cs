using System.ComponentModel.DataAnnotations.Schema;

namespace BlackCats_Domain.Entities
{
    public  class Client:BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } =string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public DateOnly AgreementDate { get; set; }

        public int TotalEmployees { get; set; }

        public int SecurityDeposit { get; set; }

        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }


        #region NavigationProperties
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } =null!;

        //[ForeignKey(nameof(Id))]
        //public AppFile AppFile { get; set; } = null!;

        #endregion

    }
}
