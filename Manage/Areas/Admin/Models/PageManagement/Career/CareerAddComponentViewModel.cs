using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Career
{
    public class CareerAddComponentViewModel
    {
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

        public string ContentCareer_AZ { get; set; }

        public string ContentCareer_RU { get; set; }

        [Required]
        public string ContentCareer_EN { get; set; }

        public string ContentCareer_TR { get; set; }

        public bool ShowVacancies { get; set; }
        public bool IsBanner { get; set; }
        public bool ImageOnRight { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Career { get; set; }
    }
}
