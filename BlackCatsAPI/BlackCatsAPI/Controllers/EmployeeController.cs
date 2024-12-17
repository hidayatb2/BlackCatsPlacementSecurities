using BlackCats_Application.RRModels;
using BlackCats_Application.Services;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ApiController
    {
        private readonly EmployeeService service;

        public EmployeeController(EmployeeService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IResult> AddEmployee(EmployeeRequest model) => this.ApiResult(await service.AddEmployee(model));

        [HttpGet("{pageSize},{pageNo}")]
        public async Task<IResult> GetAllEmps(int pageNo,int pageSize) => this.ApiResult(await service.GetAllEmployee( pageNo, pageSize));

        [HttpDelete("{id:guid}")]

        public async Task<IResult> DeleteEmps(Guid id)=>this.ApiResult(await service.DeleteEmployee(id));

        [HttpPut]
        public async Task<IResult> UpdateEmp(EmployeeUpdateRequest model) => this.ApiResult(await service.UpdateEmployee(model));

        [HttpGet("{id}")]

        public async Task<IResult> GetById(Guid id)=>this.ApiResult(await service.GetEmployeeById(id));
        
    }
}
