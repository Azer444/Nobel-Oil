using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.DynamicPageManagement
{
    public class ContentDetailsViewModel
    {
        [Display(Name = "Content title (AZ)")]
        public string ContentTitle_AZ { get; set; }

        [Display(Name = "Content title (RU)")]
        public string ContentTitle_RU { get; set; }

        [Display(Name = "Content title (EN)")]
        public string ContentTitle_EN { get; set; }

        [Display(Name = "Content title (TR)")]
        public string ContentTitle_TR { get; set; }

        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        [Display(Name = "Is content title?")]
        public bool IsContentTitle { get; set; }

        public string ContentPhotoName { get; set; }

        public int DynamicPageId { get; set; }

    }
}
