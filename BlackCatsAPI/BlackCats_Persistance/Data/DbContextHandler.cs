using BlackCats_Application.Utilities;
using BlackCats_Domain.Entities;
using BlackCats_Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance.Data
{
    internal class DbContextHandler
    {
        internal void SeedInitialData(ModelBuilder modelBuilder)
        {
            SeedAdmin(modelBuilder);
        }


        private void SeedAdmin(ModelBuilder modelBuilder)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@gmail.com",
                Name = "Admin",
                PasswordSalt = AppEncryption.GenerateSalt(),
                IsDeleted = false,
                UserName = "admin",
                UserRole = UserRole.Admin,
                UserStatus = UserStatus.Active,
                ContactNo = "7006342430",
                CreatedAt = DateTime.Now,
            };
            user.PasswordHash = AppEncryption.PasswordHashing("admin", user.PasswordSalt);
            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
