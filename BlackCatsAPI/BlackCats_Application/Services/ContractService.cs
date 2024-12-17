using AutoMapper;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository repository;
        private readonly IMapper mapper;

        public ContractService(IContractRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<APIResponse<ContractRes>> AddContract(ContractReq model)
        {
            Contract Contract = mapper.Map<Contract>(model);
            var retVal = await repository.AddAsync(Contract);

            if (retVal > 0)
            {
                return APIResponse<ContractRes>.SuccessResponse(mapper.Map<ContractRes>(model));
            }
            else
            {
                return APIResponse<ContractRes>.ErrorResponse("There is Some Error please Try After Sometime", APIStatusCodes.InternalServerError);
            }
        }

        public Task<APIResponse<string>> DeleteContractById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<ContractRes>>> GetAllContracts()
        {
            var res = await repository.GetAllByAsync();

            if (res is not null)
            {
                return APIResponse<IEnumerable<ContractRes>>.SuccessResponse(res.Select(Contract => mapper.Map<ContractRes>(Contract)));
            }

            return APIResponse<IEnumerable<ContractRes>>.ErrorResponse("No Client Found", APIStatusCodes.NoContent);
        }

        public async Task<APIResponse<ContractRes>> GetContractById(Guid id)
        {
            var client = await repository.GetbyIdAsync(id);

            if (client is not null)
            {
                return APIResponse<ContractRes>.SuccessResponse(mapper.Map<ContractRes>(client));
            }

            return APIResponse<ContractRes>.ErrorResponse("No Client Found By this Id", APIStatusCodes.BadRequest);
        }

        public async Task<APIResponse<ContractRes>> UpdateContract(ContractUpdateReq model)
        {
            var contract = await repository.GetbyIdAsync(model.ClientId);


            if (contract is not null)
            {
                contract.From = model.From;
                contract.To = model.To;

                var res = await repository.UpdateAsync(contract);
                return APIResponse<ContractRes>.SuccessResponse(mapper.Map<ContractRes>(res));
            }

            else
            {
                return APIResponse<ContractRes>.ErrorResponse("No Client Found", APIStatusCodes.BadRequest);

            }
        }
    }
}
