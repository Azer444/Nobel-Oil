using Core.Models.Abstraction;
using System;

namespace Core.Models
{
    public class ImageGalleryComponentPhoto : ITiming
    {
        public int Id { get; set; }

        public string PhotoName { get; set; }

        public ImageGalleryComponent ImageGalleryComponent { get; set; }

        public int ImageGalleryComponentId { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
