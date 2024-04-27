using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Manage.Validations.FileSize
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileSizeAttribute : ValidationAttribute
    {
        public double? Size { get; set; }
        public FileSizeAttribute(string size = null)
        {
            if (size != null)
                Size = Convert.ToDouble(size);
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
                    result = CheckSize(file, validationContext);

                    if (!string.IsNullOrEmpty(result))
                    {
                        return new ValidationResult(result);
                    }
                }

                return ValidationResult.Success;
            }


            //for single
            IFormFile formFile = (IFormFile)value;
            result = CheckSize(formFile, validationContext);

            if (string.IsNullOrEmpty(result))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(result);
        }

        private string CheckSize(IFormFile file, ValidationContext validationContext)
        {
            var fileService = (IFileService)validationContext.GetService(typeof(IFileService));

            StringBuilder errorMessages = new StringBuilder();

            if (fileService.CheckSize(file, errorMessages, Size))
            {
                return string.Empty;
            }

            return errorMessages.ToString();
        }

    }
}
