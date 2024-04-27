using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Environment
{
    public class EnvironmentAddSubComponentViewModel
    {
        public EnvironmentAddSubComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string ContentEnvironment_AZ { get; set; }

        public string ContentEnvironment_RU { get; set; }

        [Required]
        public string ContentEnvironment_EN { get; set; }

        public string ContentEnvironment_TR { get; set; }

        public bool isBanner { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Environment { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public List<IFormFile> Photos { get; set; }
    }
}
