using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class SustainabilityReport : ITiming
    {
        public int Id { get; set; }

        #region Title

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        #endregion

        #region Content

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        #endregion

        [Display(Name = "File (AZ)")]
        public string FileName_AZ { get; set; }

        [Display(Name = "File (RU)")]
        public string FileName_RU { get; set; }

        [Display(Name = "File (EN)")]
        public string FileName_EN { get; set; }

        [Display(Name = "File (TR)")]
        public string FileName_TR { get; set; }

        [Display(Name = "Photo")]
        public string PhotoName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
