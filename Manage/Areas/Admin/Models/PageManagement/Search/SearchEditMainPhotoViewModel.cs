using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Search
{
    public class SearchEditMainPhotoViewModel
    {
        public int Id { get; set; }
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string PhotoPath { get; set; }

        [FileContentType("Images")]
        [FileSize]
        public IFormFile Photo { get; set; }
    }
}
