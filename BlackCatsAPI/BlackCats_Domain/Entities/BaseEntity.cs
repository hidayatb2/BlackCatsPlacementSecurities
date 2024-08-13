using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? CreatedBy { get; set; } 

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
