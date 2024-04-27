using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CareerComponent : ITiming
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

        public string ContentCareer_AZ { get; set; }

        public string ContentCareer_RU { get; set; }

        [Required]
        public string ContentCareer_EN { get; set; }

        public string ContentCareer_TR { get; set; }

        public string PhotoName { get; set; }

        public string PhotoName_Career { get; set; }

        public bool ShowVacancies { get; set; }
        public bool IsBanner { get; set; }
        public bool ImageOnRight { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
