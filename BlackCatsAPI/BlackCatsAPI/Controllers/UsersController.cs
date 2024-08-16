using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Enums;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IResult> GetAllUsers()
        {
            return this.ApiResult(await service.GetAllUsers());
        }

        [HttpPost]
        public async Task<IResult> AddUsers(UserRequest model) => this.ApiResult(await service.AddUser(model));



        [HttpDelete("{id}")]

        public async Task<IResult> DeleteUserById(Guid Id)=>this.ApiResult(await service.DeleteUserById(Id));



        [HttpPut]

        public async Task<IResult> UpdateUserById(UserUpdateRequest model) => this.ApiResult(await service.UpdateUser(model));



        [HttpGet("{id}")]

        public async Task<IResult> GetUserById(Guid id)=>this.ApiResult(await service.GetUserById(id));



    }
}
