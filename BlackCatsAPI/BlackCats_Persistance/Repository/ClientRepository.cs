using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.RRModels;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;

namespace BlackCats_Persistance.Repository;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly BCPSDbContext context;

    public ClientRepository(BCPSDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<ClientResponse> GetClientResponse(Guid clientId)
    {
        string query = $@"SELECT 
	    c.id,
        c.name, 
        c.address, 
        c.securityDeposit, 
        c.contactNo,
        c.AgreementDate,
        COUNT(e.id) AS totalEmployees
    FROM 
        clients c
    LEFT JOIN 
        employees e ON c.Id = e.clientId
    GROUP BY 
        c.id, c.name, c.address, c.securityDeposit, c.contactNo, c.AgreementDate;";


        return await FirstOrDefaultAsync<ClientResponse>(query);
        

    }
}
