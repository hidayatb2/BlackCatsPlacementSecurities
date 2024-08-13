using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;

namespace BlackCats_Persistance.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly BCPSDbContext context;

        public UserRepository(BCPSDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<User> AddUsers(User model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers(User model)
        {
            string query = $@"SELECT * FROM USERS WHERE ISDELETED = FALSE";

            return await QueryAsync<User>(query);

        }

        public Task<User> GetUsersById(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}
