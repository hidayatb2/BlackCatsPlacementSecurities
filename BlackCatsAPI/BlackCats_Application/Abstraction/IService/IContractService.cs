using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IContractService
    {
        Task<APIResponse<ContractResponse>> AddContract(ContractRequest model);

        Task<APIResponse<IEnumerable<ContractResponse>>> GetAllContracts();

        Task<APIResponse<ContractResponse>> UpdateContract(ContractUpdateRequest model);

        Task<APIResponse<ContractResponse>> GetContractById(Guid id);

        Task<APIResponse<string>> DeleteContractById(Guid id);
    }
}
