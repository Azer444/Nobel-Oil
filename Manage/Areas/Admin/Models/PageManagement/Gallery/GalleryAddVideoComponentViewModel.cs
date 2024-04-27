using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Gallery
{
    public class GalleryAddVideoComponentViewModel
    {
        [Required]
        public string Link { get; set; }

        public int Order { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
