using BlackCats_Application.Abstraction.IService;
using Microsoft.AspNetCore.Http;

namespace BlackCats_Infrastructure.Storage_Services;

public class LocalStorage : IStorageService
{
    private readonly string webRootPath;

    public LocalStorage(string webRootPath)
    {
        this.webRootPath = webRootPath;

    }
    public async Task<bool> DeleteFileAsync(string FilePath)
    {
        string BasePath = GetPhysicalDirPath();
        string fullPath = Path.Combine(BasePath, FilePath);
        if (!(File.Exists(fullPath)))
            return false;

        await Task.Run(() => File.Delete(fullPath));
        return true;
    }

    public Task<bool> DeleteFilesAsync(IEnumerable<string> FilesPath)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var absPath = GetPhysicalDirPath();


        if (!(Directory.Exists(absPath)))
            Directory.CreateDirectory(absPath);

        string newFileName = string.Concat(Guid.NewGuid(), Path.GetExtension(file.FileName).ToLower());
        string fullPath = Path.Combine(absPath, newFileName);
        using FileStream fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);

        return Path.Combine("Files", newFileName);
    }

    public Task<string> UploadFilesAsync(IFormFile[] files)
    {
        throw new NotImplementedException();
    }

    private string GetPhysicalDirPath() => Path.Combine(webRootPath, "Files");
}
