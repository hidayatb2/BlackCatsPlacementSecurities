using AutoMapper;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Application.Utilities;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.Services;

public class AccountService : IAccountService
{
    private readonly ITokenService _tokenService;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(ITokenService tokenService, IAccountRepository accountRepository, IMapper mapper)
    {
        _tokenService = tokenService;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<APIResponse<LoginResponse>> Login(LoginDto loginDto)
    {
        var user = _accountRepository.Findby<User>(u => u.Email == loginDto.Email).FirstOrDefault();
        if (loginDto is null || user is null ) return APIResponse<LoginResponse>.ErrorResponse("Enter valid Email", APIStatusCodes.NotFound);

        if (!AppEncryption.VerifyPassword(loginDto.Password, user.PasswordHash)) return APIResponse<LoginResponse>.ErrorResponse("Invalid Credentials", APIStatusCodes.Unauthorized);

        LoginResponse loginResponse = _mapper.Map<LoginResponse>(user);
        loginResponse.Token = _tokenService.GenerateJWToken(loginResponse);

        return APIResponse<LoginResponse>.SuccessResponse(loginResponse, APIStatusCodes.OK, APIMessages.Success);
    }
}
