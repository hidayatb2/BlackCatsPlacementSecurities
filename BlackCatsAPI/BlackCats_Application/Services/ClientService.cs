using AutoMapper;
using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using BlackCats_Domain.Entities;

namespace BlackCats_Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;
        private readonly IMapper mapper;
        private readonly IFileService fileService;

        public ClientService(IClientRepository repository, IMapper mapper, IFileService fileService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.fileService = fileService;
        }
        public async Task<APIResponse<ClientResponse>> AddClient(ClientRequest model)
        {
            Client clientModel = mapper.Map<Client>(model);
            if(model.AgreementDocument is not null)
            {
                var files = await fileService.AddFile(model.AgreementDocument, clientModel.Id);

            }

            model.SecurityDeposit=(int)model.SecurityDeposit;
            var returnVal = await repository.AddAsync(clientModel);

            if (returnVal > 0)
            {
                return APIResponse<ClientResponse>.SuccessResponse(mapper.Map<ClientResponse>(model));
            }
            else
            {
                return APIResponse<ClientResponse>.ErrorResponse("There is Some Error please Try After Sometime", APIStatusCodes.InternalServerError);
            }

        }

        public Task<APIResponse<string>> DeleteClient(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<ClientResponse>>> GetAllClients()
        {
            var res = await repository.GetAllByAsync();

            if (res is null)
            {
                return APIResponse<IEnumerable<ClientResponse>>.ErrorResponse("No Client Found", APIStatusCodes.NoContent);
            }

            return APIResponse<IEnumerable<ClientResponse>>.SuccessResponse(res.Select(client => mapper.Map<ClientResponse>(client)));
        }

        public async Task<APIResponse<UserResponse>> GetClienteById(Guid Id)
        {
            var client = await repository.GetbyIdAsync(Id);

            if (client is null)
            {
                return APIResponse<UserResponse>.ErrorResponse("No Client Found By this Id", APIStatusCodes.BadRequest);
            }

            return APIResponse<UserResponse>.SuccessResponse(mapper.Map<UserResponse>(client));
        }

        public async Task<APIResponse<ClientResponse>> UpdateCliente(ClientUpdateRequest model)
        {
            var client = await repository.GetbyIdAsync(model.ClientId);


            if (client is null)
            {
                return APIResponse<ClientResponse>.ErrorResponse("No Client Found", APIStatusCodes.BadRequest);

            }

            else
            {
                client.Name = model.Name;
                client.Address = model.Address;
                client.ContactNo = model.ContactNo;
                client.SecurityDeposit = model.SecurityDeposit;
                var filepath = await fileService.AddFile(model.AgreementDocument, model.ClientId);
                var res = await repository.UpdateAsync(client);
                if (res > 0)
                {
                    var response=mapper.Map<ClientResponse>(client);
                    response.DocumentPath = filepath;
                return APIResponse<ClientResponse>.SuccessResponse(response);

                }
                return APIResponse<ClientResponse>.ErrorResponse("there is some error please try again later");
               
            }

        }
    }
}
