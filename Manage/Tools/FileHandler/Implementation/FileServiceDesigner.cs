using EcomLab.Core.Constants.File;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manage.Tools.FileHandler.Implementation
{
    public partial class FileService
    {
        private readonly Dictionary<string, string> _allowedContentTypes;
        private readonly double _allowedMaxUploadSize;
        private readonly string _uploadDirectory;
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
            _uploadDirectory = configuration.GetSection("UploadDirectory").Value;
            _allowedContentTypes = configuration.GetSection("AllowedContentTypes").GetChildren()
                .ToDictionary(x => x.Key, x => x.Value);
            _allowedMaxUploadSize = Convert.ToDouble(configuration.GetSection("MaxUploadSize").Value);
        }

        /// <summary>
        /// Checks whether posted file's content type(s) are allowed by system or not.
        /// Allowed content types are given in appsettings.json
        /// </summary>
        private void IsAllowedContentTypes(List<string> contentTypes)
        {
            foreach (string contentType in contentTypes)
            {
                if (!_allowedContentTypes.ContainsValue(contentType))
                    throw new Exception($"Provided content type <{contentType}> is not allowed by system. Please check appsettings.json file.");
            }
        }

        /// <summary>
        /// Checks whether posted file's size are allowed by system or not.
        /// Allowed max size is given in appsettings.json
        /// </summary>
        private void IsAllowedMaxSize(double size)
        {
            if (_allowedMaxUploadSize < size)
                throw new Exception($"Provided size <{size / StorageUnits.Megabyte} MB> is not allowed by system. Please check appsettings.json file.");
        }

        /// <summary>
        /// If argument is given then it will return extension of content type
        /// Otherwise it will return allowed file types which are given in appsettings.json
        /// </summary>
        private string GetValidExtensions(List<string> contentTypes = null)
        {
            List<string> extensions = new List<string>();

            if (contentTypes != null)
            {
                foreach (var contentType in contentTypes)
                {
                    string extension = _allowedContentTypes.FirstOrDefault(ct => ct.Value == contentType).Key;
                    if (extension != null) extensions.Add(extension);
                }
            }
            else
                extensions.AddRange(_allowedContentTypes.Keys);

            return string.Join(", ", extensions);
        }
    }
}
