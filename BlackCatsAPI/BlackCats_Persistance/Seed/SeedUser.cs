using BlackCats_Application.Utilities;
using BlackCats_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance.Seed
{
    public class SeedUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            using HMACSHA256 hmac = new HMACSHA256();
            User user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Name = "admin",
                ContactNo = "7006342430",
                Email = "admin@gmail.com",
                CreatedAt = DateTime.Now,
                PasswordSalt = AppEncryption.GenerateSalt(),
                UserRole = BlackCats_Domain.Enums.UserRole.Admin,
                UserStatus = BlackCats_Domain.Enums.UserStatus.Active,
                IsDeleted = false
            };
            user.PasswordHash = AppEncryption.PasswordHashing("admin", user.PasswordSalt);
            builder.HasData(user);
        }
    }
}
