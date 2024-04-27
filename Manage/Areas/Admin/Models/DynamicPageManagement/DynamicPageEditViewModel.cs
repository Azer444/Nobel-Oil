using Core.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.DynamicPageManagement
{
    public class DynamicPageEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        public string BannerPhotoPath { get; set; }

        [Display(Name = "Banner photo")]
        public IFormFile BannerPhoto { get; set; }

        [Required]
        [Display(Name = "Banner title (AZ)")]
        public string BannerTitle_AZ { get; set; }

        [Display(Name = "Banner title (RU)")]
        public string BannerTitle_RU { get; set; }

        [Required]
        [Display(Name = "Banner title (EN)")]
        public string BannerTitle_EN { get; set; }

        [Display(Name = "Banner title (TR)")]
        public string BannerTitle_TR { get; set; }

        [Display(Name = "Has component?")]
        public bool HasComponent { get; set; }

        [Required]
        [Display(Name = "Title page (AZ)")]
        public string TitlePage_AZ { get; set; }

        [Display(Name = "Title page (RU)")]
        public string TitlePage_RU { get; set; }

        [Required]
        [Display(Name = "Title page (EN)")]
        public string TitlePage_EN { get; set; }

        [Display(Name = "Title page (TR)")]
        public string TitlePage_TR { get; set; }

        [Required]
        [Display(Name = "Content page (AZ)")]
        public string ContentPage_AZ { get; set; }

        [Display(Name = "Content page (RU)")]
        public string ContentPage_RU { get; set; }

        [Required]
        [Display(Name = "Content page (EN)")]
        public string ContentPage_EN { get; set; }

        [Display(Name = "Content page (TR)")]
        public string ContentPage_TR { get; set; }

        public string PagePhotoPath { get; set; }

        [Display(Name = "Page photo")]
        public IFormFile PagePhoto { get; set; }

        [Display(Name = "Is banner?")]
        public bool IsBanner { get; set; }

        [Required]
        [Display(Name = "Page")]
        public Page Page { get; set; }
    }
}
