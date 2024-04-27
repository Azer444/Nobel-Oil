using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.Testimonial
{
    public class TestimonialDetailsViewModel
    {
        #region Writer

        [Display(Name = "Writer (AZ)")]
        public string Writer_AZ { get; set; }

        [Display(Name = "Writer (RU)")]
        public string Writer_RU { get; set; }

        [Required]
        [Display(Name = "Writer (EN)")]
        public string Writer_EN { get; set; }

        [Display(Name = "Writer (TR)")]
        public string Writer_TR { get; set; }

        #endregion

        #region WriterInfo

        [Display(Name = "Writer info (AZ)")]
        public string WriterInfo_AZ { get; set; }

        [Display(Name = "Writer info (RU)")]
        public string WriterInfo_RU { get; set; }

        [Required]
        [Display(Name = "Writer info (EN)")]
        public string WriterInfo_EN { get; set; }

        [Display(Name = "Writer info (TR)")]
        public string WriterInfo_TR { get; set; }

        #endregion
        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        public string PhotoPath { get; set; }
    }
}
