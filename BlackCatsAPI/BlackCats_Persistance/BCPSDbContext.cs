using BlackCats_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance
{
    public class BCPSDbContext:DbContext
    {
        public BCPSDbContext(DbContextOptions<BCPSDbContext> context):base(context)
        {


        }
        public DbSet<User> Users { get; set; }

    }
}
