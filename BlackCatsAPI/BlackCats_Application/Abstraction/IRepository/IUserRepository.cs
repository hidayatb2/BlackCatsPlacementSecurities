﻿using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IRepository
{
    public interface IUserRepository:IBaseRepository<User>
    {

        Task<IEnumerable<User>> GetAllUsers(User model);

        Task<User> GetUsersById(Guid Id);

        Task <User> AddUsers(User model);
    }
}
