using Microsoft.EntityFrameworkCore;

namespace BlackCats.Persistence.Data.Context
{
    public class BlackCatsDbContext :DbContext
    {
        public BlackCatsDbContext(DbContextOptions<BlackCatsDbContext> options) :base(options)  
        {
            
        }
    }
}

