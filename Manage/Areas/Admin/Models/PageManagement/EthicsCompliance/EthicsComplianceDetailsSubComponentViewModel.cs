using Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.EthicsCompliance
{
    public class EthicsComplianceDetailsSubComponentViewModel
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

        public string Slug { get; set; }

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

        [Display(Name = "Photo EC")]
        public string PhotoPath_EC { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        #region ContentEC

        [Display(Name = "Content EC (AZ)")]
        public string ContentEC_AZ { get; set; }

        [Display(Name = "Content EC (RU)")]
        public string ContentEC_RU { get; set; }

        [Required]
        [Display(Name = "Content EC (EN)")]
        public string ContentEC_EN { get; set; }

        [Display(Name = "Content EC (TR)")]
        public string ContentEC_TR { get; set; }

        #endregion

        [Display(Name = "Is banner")]
        public bool isBanner { get; set; }

        [Display(Name = "Submit form")]
        public bool SubmitForm { get; set; }

        public ICollection<EthicsComplianceSubComponentPdf> EthicsComplianceSubComponentPdfs { get; set; }
    }
}
