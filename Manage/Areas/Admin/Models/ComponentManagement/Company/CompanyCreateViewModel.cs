using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.Company
{
    public class CompanyCreateViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string TitleCareer_AZ { get; set; }

        public string TitleCareer_RU { get; set; }

        [Required]
        public string TitleCareer_EN { get; set; }

        public string TitleCareer_TR { get; set; }
        public string Link_Career { get; set; }

        [Required]
        public string Slug { get; set; }


        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string ContentWWD_AZ { get; set; }

        public string ContentWWD_RU { get; set; }

        [Required]
        public string ContentWWD_EN { get; set; }

        public string ContentWWD_TR { get; set; }


        public bool ShowOnCareer { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_WWD { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Career { get; set; }
    }
}
