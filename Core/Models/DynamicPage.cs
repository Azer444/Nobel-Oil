using Core.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class DynamicPage
    {
        public DynamicPage()
        {
            DynamicPageContents = new HashSet<DynamicPageContent>();
        }
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

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

        [Required]
        [Display(Name = "Banner photo")]
        public string BannerPhotoName { get; set; }

        public virtual ICollection<DynamicPageContent> DynamicPageContents { get; set; }

        [Display(Name = "Has banner component?")]
        public bool HasPageComponent { get; set; }

        #region For page component

        [Display(Name = "Title page (AZ)")]
        public string TitlePage_AZ { get; set; }

        [Display(Name = "Title page (RU)")]
        public string TitlePage_RU { get; set; }

        [Display(Name = "Title page (EN)")]
        public string TitlePage_EN { get; set; }

        [Display(Name = "Title page (TR)")]
        public string TitlePage_TR { get; set; }

        [Display(Name = "Title page (AZ)")]
        public string ContentPage_AZ { get; set; }

        [Display(Name = "Title page (RU)")]
        public string ContentPage_RU { get; set; }

        [Display(Name = "Title page (EN)")]
        public string ContentPage_EN { get; set; }

        [Display(Name = "Title page (TR)")]
        public string ContentPage_TR { get; set; }

        public Page Page { get; set; }

        [Display(Name = "Page Photo")]
        public string PagePhotoName { get; set; }

        [Display(Name = "Is banner?")]
        public bool IsBanner { get; set; }

        #endregion
    }
}
