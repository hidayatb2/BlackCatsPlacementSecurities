using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Services;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagesController : ApiController
    {
        private readonly IWagesService service;

        public WagesController(IWagesService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IResult> AddWaged(WagesRequest model) => this.ApiResult(await service.AddWages(model));

        [HttpGet("{pageSize},{pageNo}")]
        public async Task<IResult> GetAllWages(int pageNo, int pageSize) => this.ApiResult(await service.GetAllWages(pageNo, pageSize));

        [HttpDelete("{id:guid}")]

        public async Task<IResult> DeleteWage(Guid id) => this.ApiResult(await service.DeleteWages(id));

        [HttpPut]
        public async Task<IResult> UpdateWage(WagesUpdateRequest model) => this.ApiResult(await service.UpdateWages(model));

        [HttpGet("{id}")]

        public async Task<IResult> GetWageById(Guid id) => this.ApiResult(await service.GetWagesById(id));
    }
}
