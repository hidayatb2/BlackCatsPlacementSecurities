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
    public class FileRepository :BaseRepository<AppFile>,IFileRepository
    {
        public FileRepository(BCPSDbContext context):base(context)
        {
            
        }
    }
}
