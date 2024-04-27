using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Flatpage
    {
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

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

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        #endregion

        [Required]
        [Display(Name = "Banner Photo")]
        public string BannerPhotoName { get; set; }

        //For page component

        public bool HasPageComponent { get; set; }

        #region TitlePage

        public string TitlePage_AZ { get; set; }

        public string TitlePage_RU { get; set; }

        public string TitlePage_EN { get; set; }

        public string TitlePage_TR { get; set; }

        #endregion

        #region ContentPage

        public string ContentPage_AZ { get; set; }

        public string ContentPage_RU { get; set; }

        public string ContentPage_EN { get; set; }

        public string ContentPage_TR { get; set; }

        #endregion

        public Page Page { get; set; }

        public string PagePhotoName { get; set; }

        public bool IsBanner { get; set; }

        //

    }
}
