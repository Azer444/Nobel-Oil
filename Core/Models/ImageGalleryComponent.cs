using Core.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ImageGalleryComponent : ITiming
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string PhotoName { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Navigation Properties
        public ICollection<ImageGalleryComponentPhoto> ImageGalleryComponentPhotos { get; set; }
    }
}
