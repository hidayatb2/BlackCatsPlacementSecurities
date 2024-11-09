using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public  interface IStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);

        Task<string> UploadFilesAsync(IFormFile[] files);

        Task<bool> DeleteFileAsync(string FilePath);

        Task<bool> DeleteFilesAsync(IEnumerable<string> FilesPath);
    }
}
