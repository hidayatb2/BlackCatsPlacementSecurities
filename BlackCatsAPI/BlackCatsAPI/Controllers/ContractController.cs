using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ApiController
    {
        private readonly IContractService service;

        public ContractController(IContractService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IResult> GetClients() => this.ApiResult(await service.GetAllContracts());

        [HttpPost]

        public async Task<IResult> AddClient(ContractRequest model) => this.ApiResult(await service.AddContract(model));

        [HttpPut]

        public async Task<IResult> UpdateClient(ContractUpdateRequest model) => this.ApiResult(await service.UpdateContract(model));

        [HttpGet("{Id}")]

        public async Task<IResult> GetClientById(Guid Id) => this.ApiResult(await service.GetContractById(Id));
    }
}
