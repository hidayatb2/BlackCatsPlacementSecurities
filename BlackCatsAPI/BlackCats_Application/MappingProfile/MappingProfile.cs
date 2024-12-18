using AutoMapper;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.MappingProfile;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<UserRequest, User>();
        CreateMap<User, UserUpdateResponse>();

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
}

public class ContractProfile : Profile
{
    public ContractProfile()
    {
        CreateMap<ContractRequest, Contract>();
        CreateMap<Contract, ContractResponse>();
        CreateMap<ContractRequest, ContractResponse>();
        CreateMap<ContractUpdateRequest, Contract>();

    }
}

