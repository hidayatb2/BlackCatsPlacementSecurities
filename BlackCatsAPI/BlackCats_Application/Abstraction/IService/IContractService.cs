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
        Task<APIResponse<ContractRes>> AddContract(ContractReq model);

        Task<APIResponse<IEnumerable<ContractRes>>> GetAllContracts();

        Task<APIResponse<ContractRes>> UpdateContract(ContractUpdateReq model);

        Task<APIResponse<ContractRes>> GetContractById(Guid id);

        Task<APIResponse<string>> DeleteContractById(Guid id);
    }
}
