using BlackCats_Application.Abstraction.IRepository;
using BlackCats_Application.Abstraction.IService;
using BlackCats_Domain.Entities;
using BlackCats_Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BlackCats_Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository repository;
        private readonly IStorageService storageService;
        private readonly IContextService contextAccessor;

        public FileService(IFileRepository repository,IStorageService storageService,IContextService contextAccessor)
        {
            this.repository = repository;
            this.storageService = storageService;
            this.contextAccessor = contextAccessor;
        }
        public async Task<string> AddFile(IFormFile File, Guid ClientId)
        {
          var returnPath= await storageService.UploadFileAsync(File);
            string fileType = Path.GetExtension(File.FileName).ToLower();
            
            AppFile appFile = new AppFile
            {
                FilePath = returnPath,
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.Parse(contextAccessor.GetUserId()),
                ModuleType = EntityModule.Client,
                ModuleId = ClientId,
            };
            if (fileType == "pdf")
            {
                appFile.FileType = FileType.Document;
            }
            else if (new[] { "jpg", "jpeg", "png" }.Contains(fileType))
            {
                appFile.FileType = FileType.Image;
            }
            if (ClientId==Guid.Empty)
                return "Client ";
            else
            {
            var returnVal= await repository.AddAsync(appFile);

                if (returnVal > 0)
                    return returnPath;
            }
            return "";
           
        }

        public Task<string> AddFiles(IFormFile[] files)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFile(IFormFile File)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFiles(IEnumerable<string> FilesPath)
        {
            throw new NotImplementedException();
        }
    }
}
