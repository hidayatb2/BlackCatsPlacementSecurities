using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IUserService
    {
        Task<APIResponse<UserResponse>> AddUser(UserRequest model);

        Task<APIResponse<IEnumerable<UserResponse>>> GetAllUsers();

        Task <APIResponse<UserUpdateResponse>> UpdateUser(UserUpdateRequest model);

        Task<APIResponse<UserResponse>> GetUserById(Guid id);

        Task <APIResponse<string>> DeleteUserById(Guid id);
    }
}
