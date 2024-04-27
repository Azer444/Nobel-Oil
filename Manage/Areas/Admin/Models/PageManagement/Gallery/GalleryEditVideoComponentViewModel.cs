using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Gallery
{
    public class GalleryEditVideoComponentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }

        public int Order { get; set; }

        public string PhotoName { get; set; }

        public IFormFile Photo { get; set; }
    }
}
