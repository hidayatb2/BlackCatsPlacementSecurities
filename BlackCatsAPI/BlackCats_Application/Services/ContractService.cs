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

        public async Task<APIResponse<ContractResponse>> AddContract(ContractRequest model)
        {
            Contract Contract = mapper.Map<Contract>(model);
            var retVal = await repository.AddAsync(Contract);

            if (retVal > 0)
            {
                return APIResponse<ContractResponse>.SuccessResponse(mapper.Map<ContractResponse>(model));
            }
            else
            {
                return APIResponse<ContractResponse>.ErrorResponse("There is Some Error please Try After Sometime", APIStatusCodes.InternalServerError);
            }
        }

        public Task<APIResponse<string>> DeleteContractById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<ContractResponse>>> GetAllContracts()
        {
            var res = await repository.GetAllByAsync();

            if (res is not null)
            {
                return APIResponse<IEnumerable<ContractResponse>>.SuccessResponse(res.Select(Contract => mapper.Map<ContractResponse>(Contract)));
            }

            return APIResponse<IEnumerable<ContractResponse>>.ErrorResponse("No Client Found", APIStatusCodes.NoContent);
        }

        public async Task<APIResponse<ContractResponse>> GetContractById(Guid id)
        {
            var client = await repository.GetbyIdAsync(id);

            if (client is not null)
            {
                return APIResponse<ContractResponse>.SuccessResponse(mapper.Map<ContractResponse>(client));
            }

            return APIResponse<ContractResponse>.ErrorResponse("No Client Found By this Id", APIStatusCodes.BadRequest);
        }

        public async Task<APIResponse<ContractResponse>> UpdateContract(ContractUpdateRequest model)
        {
            var contract = await repository.GetbyIdAsync(model.ClientId);


            if (contract is not null)
            {
                contract.From = model.From;
                contract.To = model.To;

                var res = await repository.UpdateAsync(contract);
                return APIResponse<ContractResponse>.SuccessResponse(mapper.Map<ContractResponse>(res));
            }

            else
            {
                return APIResponse<ContractResponse>.ErrorResponse("No Client Found", APIStatusCodes.BadRequest);

            }
        }
    }
}
