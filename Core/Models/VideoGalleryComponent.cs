using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class VideoGalleryComponent : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        [Required]
        public string Link { get; set; }

        public int Order { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
