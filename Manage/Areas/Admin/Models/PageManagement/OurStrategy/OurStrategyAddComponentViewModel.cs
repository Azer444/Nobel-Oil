using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.OurStrategy
{
    public class OurStrategyAddComponentViewModel
    {
        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }

        [Required]
        public IFormFile Photo { get; set; }


        [Display(Name = "Is banner")]
        public bool IsBanner { get; set; }
    }
}
