using EcomLab.Core.Constants.File;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Tools.FileHandler.Implementation

{
    public partial class FileService : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file, string path)
        {
            if (path != null)
            {
                string unique_filename = Guid.NewGuid() + "_" + file.FileName;

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path);
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, unique_filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return unique_filename;
            }

            return String.Empty;
        }

        public void Delete(string filename, string path)
        {
            if (filename != null && path != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path, filename);

                if (File.Exists(filePath)) File.Delete(filePath);
            }

        }

        public bool CheckContentType(IFormFile file, StringBuilder errorMessage, List<string> contentTypes = null)
        {
            bool result = false;

            if (contentTypes != null)
            {
                IsAllowedContentTypes(contentTypes);
                result = contentTypes.Contains(file.ContentType);
            }
            else
                result = _allowedContentTypes.ContainsValue(file.ContentType);

            if (result == false)
                errorMessage.Append($"Allowed extensions are : {GetValidExtensions(contentTypes)}. ");

            return result;
        }

        public bool CheckSize(IFormFile file, StringBuilder errorMessage, double? size = null)
        {
            bool result = false;

            if (size != null)
            {
                IsAllowedMaxSize(size.Value);
                result = file.Length <= size;
            }
            else
                result = file.Length <= _allowedMaxUploadSize;


            if (result == false)
                errorMessage.Append($"Max file size can be {(size != null ? size.Value : _allowedMaxUploadSize) / StorageUnits.Megabyte} MB. ");

            return result;
        }

        public string GetFileUrl(string fileName, string path)
        {
            if (fileName != null && path != null)
            {
                return $"/{_uploadDirectory}/{path}/{fileName}";
            }

            return String.Empty;
        }

        public string GetPureFileName(string fileName, bool withExtension = true)
        {
            if (fileName != null)
            {
                if (fileName.Contains("_"))
                {
                    string pureFileName = fileName.Split("_", 2)[1];

                    if (withExtension)
                    {
                        return pureFileName;
                    }

                    return TruncateExtension(pureFileName);
                }

                return fileName;
            }

            return String.Empty;
        }

        public string TruncateExtension(string fileName)
        {
            if (fileName != null)
            {
                return Path.GetFileNameWithoutExtension(fileName);
            }

            return String.Empty;
        }

        public IFormFile GetFile(string fileName, string path)
        {
            if (fileName != null && path != null)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _uploadDirectory, path, fileName);

                try
                {
                    using (var stream = new FileStream(uploadPath, FileMode.Open, FileAccess.Read))
                    {
                        return new FormFile(stream, 0, stream.Length, "name", GetPureFileName(fileName));
                    }
                }
                catch (Exception)
                {

                    return null;
                }
            }

            return null;
        }

        public double GetFileSize(string fileName, string path, double unitType)
        {
            if (fileName != null && path != null)
            {
                var file = GetFile(fileName, path);

                if (file != null)
                {
                    return Math.Round(file.Length / unitType, 2);
                }
            }

            return 0;
        }
    }
}
