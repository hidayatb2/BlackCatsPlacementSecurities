using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;

namespace BlackCats_Persistance.Repository;

public class ClientRepository :BaseRepository<Client>,IClientRepository
{
    private readonly BCPSDbContext context;

    public ClientRepository(BCPSDbContext context):base(context)
    {
        this.context = context;
    }

    
}
