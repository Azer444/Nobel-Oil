using Core.Constants;
using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.News
{
    public class NewsCreateViewModel
    {
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

        public NewsType NewsType { get; set; }

        public bool ShowOnHome { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
