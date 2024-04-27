using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.PublicationReport
{
    public class PublicationReportCreateViewModel
    {
        public PublicationReportCreateViewModel()
        {
            Pdfs_AZ = new List<IFormFile>();
            Pdfs_RU = new List<IFormFile>();
            Pdfs_EN = new List<IFormFile>();
        }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string Description_AZ { get; set; }

        public string Description_RU { get; set; }

        [Required]
        public string Description_EN { get; set; }

        public string Description_TR { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        [Display(Name = "PDFs (Az)")]
        public List<IFormFile> Pdfs_AZ { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        [Display(Name = "PDFs (Ru)")]
        public List<IFormFile> Pdfs_RU { get; set; }

        [FileSize]
        [FileContentType("PDF")]
        [Display(Name = "PDFs (En)")]
        public List<IFormFile> Pdfs_EN { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
