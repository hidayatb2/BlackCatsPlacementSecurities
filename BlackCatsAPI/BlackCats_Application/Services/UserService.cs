using AutoMapper;
using BlackCats_Application.Abstraction.IEmailService;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.Abstraction.TempleteRendrer;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Application.Utilities;
using BlackCats_Domain.Entities;
using BlackCats_Domain.Enums;

namespace BlackCats_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly IEmailTemplateRenderer templateRenderer;

        public UserService(IUserRepository repository, IMapper mapper,IEmailService emailService,IEmailTemplateRenderer templateRenderer)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.emailService = emailService;
            this.templateRenderer = templateRenderer;
        }
        public async Task<APIResponse<UserResponse>> AddUser(UserRequest model)
        {
            if (await repository.IsExist(user => user.ContactNo == model.ContactNo && user.IsDeleted==false))
                return APIResponse<UserResponse>.ErrorResponse("Contact Number Already Exists Please Give Another Contact Number", APIStatusCodes.Conflict);
            else if (await repository.IsExist(user => user.Email == model.Email && user.IsDeleted==false))
                return APIResponse<UserResponse>.ErrorResponse("Email Already Exists Please Choose Another Email", APIStatusCodes.Conflict);
            else
            {
                User user = mapper.Map<User>(model);
                user.UserName = model.Email;
                user.PasswordSalt = AppEncryption.GenerateSalt();
                user.PasswordHash = AppEncryption.PasswordHashing(model.ContactNo, user.PasswordSalt);
                user.UserStatus = UserStatus.Active;
                var ReturnVal = await repository.AddAsync(user);
                if (ReturnVal > 0)
                {
                      var emailSettings = new MailSettings
                    {
                        To = new List<string>()
                        {
                            user.Email
                        },
                        Subject=APIMessages.UserCredentials,
                        Body = await templateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.ConfirmEmailWithUsername, new { CompanyName=APIMessages.CompanyInfo.CompanyName,Name=user.Name,UserName=user.Email,Password=user.ContactNo,Link=""})
                    };
                   var emailResponse= await emailService.SendEmailAsync(emailSettings);
                    return APIResponse<UserResponse>.SuccessResponse(mapper.Map<UserResponse>(user), APIStatusCodes.Created);
                }
                else return APIResponse<UserResponse>.ErrorResponse("There is Some Issue PLease Try After Sometime", APIStatusCodes.InternalServerError);

            }


        }

        public async Task<APIResponse<string>> DeleteUserById(Guid id)
        {
            var user = await repository.GetbyIdAsync(id);
            if (user == null)
            {
                return APIResponse<string>.ErrorResponse("User Not Found", APIStatusCodes.NotFound);
            }
            user.IsDeleted = true;
            var res = await repository.UpdateAsync(user);
            if (res > 0)
                return APIResponse<string>.SuccessResponse("User Deleted Successfully");
            return APIResponse<string>.ErrorResponse("Something Went Wrong Please Try After Sometime", APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var users = await repository.GetAllUsers();
            return APIResponse<IEnumerable<UserResponse>>.SuccessResponse(users.Select(user => mapper.Map<UserResponse>(user)));
        }

        public async Task<APIResponse<UserResponse>> GetUserById(Guid id)
        {
            var user = await repository.GetUserById(id);
            if (user == null) return APIResponse<UserResponse>.ErrorResponse("User Not Found", APIStatusCodes.NotFound);
            return APIResponse<UserResponse>.SuccessResponse(mapper.Map<UserResponse>(user));
        }

        public async Task<APIResponse<UserUpdateResponse>> UpdateUser(UserUpdateRequest model)
        {
            var user = await repository.GetUserById(model.Id);
            user.Name= model.Name;
            user.UserRole= model.UserRole;
            user.UserStatus= model.UserStatus;
            user.ContactNo= model.ContactNo;
            var returnVal=await repository.UpdateAsync(user);
            if (returnVal > 0) return APIResponse<UserUpdateResponse>.SuccessResponse(mapper.Map<UserUpdateResponse>(user));
            return APIResponse<UserUpdateResponse>.ErrorResponse("There Is Some Issue Please Try After Sometime",APIStatusCodes.InternalServerError);
        }
    }
}
