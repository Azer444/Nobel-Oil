using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Safety
{
    public class SafetyAddSubComponentViewModel
    {
        public SafetyAddSubComponentViewModel()
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

        public string ContentSafety_AZ { get; set; }

        public string ContentSafety_RU { get; set; }

        [Required]
        public string ContentSafety_EN { get; set; }

        public string ContentSafety_TR { get; set; }

        public bool isBanner { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Safety { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public List<IFormFile> Photos { get; set; }
    }
}
