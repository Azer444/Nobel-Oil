﻿using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.SustainableDevelopment
{
    public class SustainableDevelopmentEditComponentViewModel
    {
        public int Id { get; set; }
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string PhotoPath { get; set; }

        #region Content
        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        #endregion

        [FileContentType("Images")]
        [FileSize]
        public IFormFile Photo { get; set; }
    }
}
