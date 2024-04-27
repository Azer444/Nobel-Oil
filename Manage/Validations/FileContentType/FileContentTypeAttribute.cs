using EcomLab.Core.Constants.File;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Manage.Validations.FileContentType
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileContentTypeAttribute : ValidationAttribute
    {
        public List<string> ContentTypes { get; set; }
        public FileContentTypeAttribute(string fileType = null)
        {
            ContentTypes = fileType != null ? typeof(ContentTypeHelper).GetProperty(fileType).GetValue(null, null) as List<string> : null;
        }

        public FileContentTypeAttribute(string[] contentTypes)
        {
            ContentTypes = contentTypes.ToList();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string result = "";

            //For multiple
            if (value is List<IFormFile>)
            {
                List<IFormFile> files = (List<IFormFile>)value;

                foreach (var file in files)
                {
                    result = CheckContentType(file, validationContext);

                    if (!string.IsNullOrEmpty(result))
                    {
                        return new ValidationResult(result);
                    }
                }

                return ValidationResult.Success;
            }

            //for single
            IFormFile formFile = (IFormFile)value;
            result = CheckContentType(formFile, validationContext);

            if (string.IsNullOrEmpty(result))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(result);
        }

        private string CheckContentType(IFormFile file, ValidationContext validationContext)
        {
            var fileService = (IFileService)validationContext.GetService(typeof(IFileService));

            StringBuilder errorMessages = new StringBuilder();

            if (fileService.CheckContentType(file, errorMessages, ContentTypes))
            {
                return string.Empty;
            }

            return errorMessages.ToString();
        }
    }
}
