using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Domain.Entities;
using BlackCats_Persistance.Data;
using BlackCats_Persistance.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Persistance.Repository
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private readonly BCPSDbContext context;

        public ContractRepository(BCPSDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
