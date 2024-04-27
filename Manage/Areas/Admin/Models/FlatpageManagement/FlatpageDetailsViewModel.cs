using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.FlatpageManagement
{
    public class FlatpageDetailsViewModel
    {
        public int Id { get; set; }

        public string URL { get; set; }

        public string BannerPhotoPath { get; set; }


        #region BannerTitle

        [Display(Name = "Banner Title (AZ)")]
        public string BannerTitle_AZ { get; set; }

        [Display(Name = "Banner Title (RU)")]
        public string BannerTitle_RU { get; set; }

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

        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        #endregion
    }
}
