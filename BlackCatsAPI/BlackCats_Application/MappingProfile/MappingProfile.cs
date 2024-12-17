using AutoMapper;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.MappingProfile;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<User,UserResponse>();
        CreateMap<UserRequest, User>();
        CreateMap<User,UserUpdateResponse>();
        
    }

}

public class ClientProfile : Profile
{
    public ClientProfile() 
    {
        CreateMap<ClientRequest, Client>();
        CreateMap<Client, ClientResponse>();
        CreateMap<ClientRequest, ClientResponse>();
    
    }

    public class Employees:Profile
    {
        public Employees()
        {
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeUpdateRequest, Employee>();
            CreateMap<Employee,EmployeeUpdateResponse>();
        }
    }
}

