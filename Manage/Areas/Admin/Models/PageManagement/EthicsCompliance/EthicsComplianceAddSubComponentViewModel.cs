using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.EthicsCompliance
{
    public class EthicsComplianceAddSubComponentViewModel
    {
        public EthicsComplianceAddSubComponentViewModel()
        {
            Pdfs_AZ = new List<IFormFile>();
            Pdfs_RU = new List<IFormFile>();
            Pdfs_EN = new List<IFormFile>();
            Pdfs_TR = new List<IFormFile>();
        }

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

        [Required]
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

        [Required]
        [FileSize]
        [FileContentType("Images")]
        [Display(Name = "Photo EC")]
        public IFormFile Photo_EC { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        [Display(Name = "Photo")]
        public IFormFile Photo { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        public List<IFormFile> Pdfs_AZ { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        public List<IFormFile> Pdfs_RU { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        public List<IFormFile> Pdfs_EN { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        public List<IFormFile> Pdfs_TR { get; set; }
    }
}
