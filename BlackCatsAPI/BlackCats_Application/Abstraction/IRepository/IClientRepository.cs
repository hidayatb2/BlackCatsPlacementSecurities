using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IRepository
{
    public  interface IClientRepository : IBaseRepository<Client>
    {
        public Task<ClientResponse> GetClientResponse(Guid clientId);

    }
}
