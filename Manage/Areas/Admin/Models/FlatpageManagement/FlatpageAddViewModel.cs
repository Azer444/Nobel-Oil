using Core.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.FlatpageManagement
{
    public class FlatpageAddViewModel
    {
        [Required]
        public string URL { get; set; }

        [Required]
        public IFormFile BannerPhoto { get; set; }

        #region BannerTitle

        [Display(Name = "Banner Title (AZ)")]
        public string BannerTitle_AZ { get; set; }

        [Display(Name = "Banner Title (RU)")]
        public string BannerTitle_RU { get; set; }

        [Required]
        [Display(Name = "Banner Title (EN)")]
        public string BannerTitle_EN { get; set; }

        [Display(Name = "Banner Title (TR)")]
        public string BannerTitle_TR { get; set; }

        #endregion

        #region Content

        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        #endregion


        //Component related properties

        [Display(Name = "Has component?")]
        public bool HasComponent { get; set; }

        #region Title page

        [Display(Name = "Title page (AZ)")]
        public string TitlePage_AZ { get; set; }

        [Display(Name = "Title page (RU)")]
        public string TitlePage_RU { get; set; }

        [Display(Name = "Title page (EN)")]
        public string TitlePage_EN { get; set; }

        [Display(Name = "Title page (TR)")]
        public string TitlePage_TR { get; set; }

        #endregion

        #region Content page

        [Display(Name = "Content page (AZ)")]
        public string ContentPage_AZ { get; set; }

        [Display(Name = "Content page (RU)")]
        public string ContentPage_RU { get; set; }

        [Display(Name = "Content page (EN)")]
        public string ContentPage_EN { get; set; }

        [Display(Name = "Content page (TR)")]
        public string ContentPage_TR { get; set; }

        #endregion

        [Display(Name = "Page photo")]
        public IFormFile PagePhoto { get; set; }

        [Display(Name = "Is banner?")]
        public bool IsBanner { get; set; }

        [Display(Name = "Page")]
        public Page Page { get; set; }
    }
}
