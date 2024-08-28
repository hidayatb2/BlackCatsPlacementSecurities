using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;

namespace BlackCats_Persistance.Repository;

public class AccountRepository : BaseRepository<User>, IAccountRepository
{
    public AccountRepository(BCPSDbContext context) : base(context)
    {

    }

    public Task<IEnumerable<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmail(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    //public async Task<User> GetUserByEmail(LoginDto loginDto)
    //{
    //    string query = @$"SELECT * FROM USERS WHERE EMAIL = '{loginDto.Email}'";

    //    return await FirstOrDefaultAsync<User>(query);
    //}

    //public Task<User> GetUserById(Guid id)
    //{
    //    throw new NotImplementedException();
    //}
}
