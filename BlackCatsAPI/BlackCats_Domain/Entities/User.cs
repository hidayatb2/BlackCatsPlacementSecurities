using BlackCats_Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlackCats_Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string? ResetCode { get; set; }

        public string? RefreshToken { get; set; } = string.Empty;

        public DateTime? TokenExpires { get; set; }

        public UserRole UserRole { get; set; }

        public UserStatus UserStatus { get; set; }
    }
}
