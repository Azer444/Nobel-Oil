using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Gallery
{
    public class GalleryAddImageComponentViewModel
    {
        public GalleryAddImageComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
