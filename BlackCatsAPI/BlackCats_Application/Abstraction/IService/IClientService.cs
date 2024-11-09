using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IClientService
    {

        Task<APIResponse<ClientResponse>> AddClient(ClientRequest model);

        Task<APIResponse<IEnumerable<ClientResponse>>> GetAllClients();

        Task<APIResponse<string>> DeleteClient(Guid Id);

        Task<APIResponse<ClientResponse>> UpdateCliente(ClientUpdateRequest model);

        Task<APIResponse<UserResponse>> GetClienteById(Guid Id);

    }
}
