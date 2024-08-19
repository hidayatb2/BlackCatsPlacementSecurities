using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<APIResponse<LoginResponse>>> Login([FromBody] LoginDto loginDto)
        {
            var data = await _accountService.Login(loginDto);
            if (data is null) return Unauthorized();
            return Ok(data);
        }
    }
}
