using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance.Repository
{
    public class UserRepository :BaseRepository<User>,IUserRepository
    {
        private readonly BCPSDbContext context;

        public UserRepository(BCPSDbContext context):base(context)
        {
            this.context = context;
        }

        async Task<IEnumerable<User>> GetAllUsers(User model)
        {
            string query = $@"SELECT * FROM USERS WHERE ISDELETED = FALSE";

            return await QueryAsync<User>(query);
            
        }
    }
}
