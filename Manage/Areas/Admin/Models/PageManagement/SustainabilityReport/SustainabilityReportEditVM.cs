﻿using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.SustainabilityReport
{
    public class SustainabilityReportEditVM
    {
        public int Id { get; set; }

        [Required]
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        [FileContentType("Images")]
        [FileSize]
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }


        [FileContentType("PDF")]
        [FileSize]
        public IFormFile File_AZ { get; set; }
        public string FilePath_AZ { get; set; }


        [FileContentType("PDF")]
        [FileSize]
        public IFormFile File_RU { get; set; }
        public string FilePath_RU { get; set; }


        [FileContentType("PDF")]
        [FileSize]
        public IFormFile File_EN { get; set; }
        public string FilePath_EN { get; set; }


        [FileContentType("PDF")]
        [FileSize]
        public IFormFile File_TR { get; set; }
        public string FilePath_TR { get; set; }
    }
}
