using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IWagesService
    {
        Task<APIResponse<WagesResponse>> AddWages(WagesRequest model);

        Task<APIResponse<IEnumerable<WagesResponse>>> GetAllWages(int pageNo, int pageSize);

        Task<APIResponse<string>> DeleteWages(Guid id);

        Task<APIResponse<WagesResponse>> GetWagesById(Guid id);

        Task<APIResponse<WagesUpdateResponse>> UpdateWages(WagesUpdateRequest model);
    }
}
