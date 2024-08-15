using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IRepository
{
    public interface IAccountRepository : IUserRepository
    {
        Task<User> GetUserByEmail(LoginDto loginDto);
    }
}
