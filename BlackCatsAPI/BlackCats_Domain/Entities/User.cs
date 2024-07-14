using BlackCats_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; } =string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int ContactNo { get; set; } 

        public string Password { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public UserRole UserRole { get; set; }
    }
}
