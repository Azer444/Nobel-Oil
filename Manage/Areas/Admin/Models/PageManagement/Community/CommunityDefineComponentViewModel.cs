using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Community
{
    public class CommunityDefineComponentViewModel
    {
        public CommunityDefineComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }


        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }


        public string ContentSustainability_AZ { get; set; }

        public string ContentSustainability_RU { get; set; }

        [Required]
        public string ContentSustainability_EN { get; set; }

        public string ContentSustainability_TR { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public List<IFormFile> Photos { get; set; }
    }
}
