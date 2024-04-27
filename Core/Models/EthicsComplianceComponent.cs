using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class EthicsComplianceComponent : ITiming
    {
        public int Id { get; set; }

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

        [Display(Name = "Banner photo")]
        public string PhotoName { get; set; }


        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
