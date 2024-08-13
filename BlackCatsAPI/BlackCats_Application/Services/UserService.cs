using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Services
{
    public class UserService : IUserService
    {
        public Task<APIResponse<UserResponse>> AddUser(UserRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
