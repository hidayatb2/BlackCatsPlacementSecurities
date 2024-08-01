namespace BlackCats.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;  

        public Guid? CreatedBy { get; set; }

        public DateTimeOffset UpdatedOn { get;set; }

        public Guid? UpdatedBy { get;set; }
    }
}
