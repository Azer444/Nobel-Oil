using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Career
{
    public class CareerAddTipComponentViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public IFormFile Photo_Career { get; set; }
    }
}
