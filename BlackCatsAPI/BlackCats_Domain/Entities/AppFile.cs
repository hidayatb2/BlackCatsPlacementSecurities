using BlackCats_Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BlackCats_Domain.Entities
{
    public class AppFile:BaseEntity
    {

        public string FilePath { get; set; } = null!;

        public EntityModule ModuleType { get; set; }

        public Guid ModuleId { get; set; }
    }
}
