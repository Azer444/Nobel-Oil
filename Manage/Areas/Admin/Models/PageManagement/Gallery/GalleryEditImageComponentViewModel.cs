using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Gallery
{
    public class GalleryEditImageComponentViewModel
    {
        public GalleryEditImageComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public int Id { get; set; }
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string PhotoName { get; set; }

        public IFormFile Photo { get; set; }

        public List<IFormFile> Photos { get; set; }

        public ICollection<ImageGalleryComponentPhoto> ImageGalleryComponentPhotos { get; set; }
    }
}
