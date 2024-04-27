using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.DynamicPageManagement
{
    public class DynamicPageDetailsViewModel
    {
        public int Id { get; set; }

        public string URL { get; set; }

        [Display(Name = "Banner Photo")]
        public string BannerPhotoPath { get; set; }

        [Display(Name = "Banner title (AZ)")]
        public string BannerTitle_AZ { get; set; }

        [Display(Name = "Banner title (RU)")]
        public string BannerTitle_RU { get; set; }

        [Display(Name = "Banner title (EN)")]
        public string BannerTitle_EN { get; set; }

        [Display(Name = "Banner title (TR)")]
        public string BannerTitle_TR { get; set; }

        [Display(Name = "Content page (AZ)")]
        public string ContentPage_AZ { get; set; }

        [Display(Name = "Content page (RU)")]
        public string ContentPage_RU { get; set; }

        [Display(Name = "Content page (EN)")]
        public string ContentPage_EN { get; set; }

        [Display(Name = "Content page (TR)")]
        public string ContentPage_TR { get; set; }

    }
}
