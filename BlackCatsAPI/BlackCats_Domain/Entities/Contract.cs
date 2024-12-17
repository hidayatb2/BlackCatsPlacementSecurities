using System.ComponentModel.DataAnnotations.Schema;

namespace BlackCats_Domain.Entities
{
    public class Contract : BaseEntity
    {
        public DateOnly From { get; set; }

        public DateOnly To { get; set; }

        public Guid ClientId { get; set; }


        #region Navigation Properties

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;

        #endregion
    }
}
