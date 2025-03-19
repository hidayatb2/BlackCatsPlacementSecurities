using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCatsAPI.Controllers.Common;
using BlackCatsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] LoginDto loginDto)
        {
            return this.ApiResult(await _accountService.Login(loginDto));
            
        }
    }
}
