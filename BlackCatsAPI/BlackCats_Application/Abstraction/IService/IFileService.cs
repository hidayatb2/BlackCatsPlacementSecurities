using BlackCats_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public  interface IFileService
    {
        Task<string> AddFile(IFormFile Doc,Guid ClientId);

        Task<string> AddFiles (IFormFile[] files);

        Task<bool> DeleteFile(IFormFile File);

        Task<bool> DeleteFiles(IEnumerable<string> FilesPath);
    }
}
