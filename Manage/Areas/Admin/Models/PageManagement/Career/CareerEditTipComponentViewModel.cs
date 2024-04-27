using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Career
{
    public class CareerEditTipComponentViewModel
    {
        public int Id { get; set; }
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


        public string PhotoName { get; set; }


        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }

        public string PhotoName_Career { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Career { get; set; }
    }
}
