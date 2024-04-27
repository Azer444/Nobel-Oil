using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Tools.FileHandler.Abstraction
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string path);
        void Delete(string filename, string path);
        bool CheckContentType(IFormFile file, StringBuilder errorMessage, List<string> contentTypes = null);
        bool CheckSize(IFormFile file, StringBuilder errorMessage, double? size = null);
        string GetFileUrl(string fileName, string path);
        string GetPureFileName(string fileName, bool withExtension = true);
        IFormFile GetFile(string fileName, string path);
        double GetFileSize(string fileName, string path, double unitType);
        string TruncateExtension(string fileName);
    }
}
