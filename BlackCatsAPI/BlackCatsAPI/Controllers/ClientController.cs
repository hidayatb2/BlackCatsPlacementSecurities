using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ApiController
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IResult> GetClients() => this.ApiResult(await service.GetAllClients());

        [HttpPost]

        public async Task<IResult> AddClient(ClientRequest model) => this.ApiResult(await service.AddClient(model));

        [HttpPut]

        public async Task<IResult> UpdateClient(ClientUpdateRequest model) => this.ApiResult(await service.UpdateCliente(model));

        [HttpGet("{Id}")]

        public async Task<IResult> GetClientById(Guid Id) => this.ApiResult(await service.GetClienteById(Id));
    }
}
