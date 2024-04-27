using Core.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class SafetySubComponent : ITiming
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        [Required]
        public string PhotoName_Safety { get; set; }

        public string ContentSafety_AZ { get; set; }

        public string ContentSafety_RU { get; set; }

        [Required]
        public string ContentSafety_EN { get; set; }

        public string ContentSafety_TR { get; set; }

        [NotMapped]
        public List<string> SplitedContent_AZ { get; set; }
        [NotMapped]
        public List<string> SplitedContent_RU { get; set; }
        [NotMapped]
        public List<string> SplitedContent_EN { get; set; }
        [NotMapped]
        public List<string> SplitedContent_TR { get; set; }


        public bool isBanner { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //

        public ICollection<SafetySubComponentPhoto> SafetySubComponentPhotos { get; set; }
    }
}
