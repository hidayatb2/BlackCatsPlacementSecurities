using AutoMapper;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginResponse>();
        }

    }
}
