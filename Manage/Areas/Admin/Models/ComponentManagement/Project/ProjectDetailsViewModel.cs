using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.Project
{
    public class ProjectDetailsViewModel
    {
        #region Title

        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        #endregion

        #region Description

        [Display(Name = "Description (AZ)")]
        public string Description_AZ { get; set; }

        [Display(Name = "Description (RU)")]
        public string Description_RU { get; set; }

        [Required]
        [Display(Name = "Description (EN)")]
        public string Description_EN { get; set; }

        [Display(Name = "Description (TR)")]
        public string Description_TR { get; set; }

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

        public string Slug { get; set; }

        [Display(Name = "Show on home")]
        public bool ShowOnHome { get; set; }

        public string MainPhotoPath { get; set; }

        public string PhotoPath { get; set; }
    }
}
