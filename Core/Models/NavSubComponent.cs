using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class NavSubComponent : ITiming
    {
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        //[Required]
        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        //[Required]
        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        public NavComponent NavComponent { get; set; }

        [Required]
        [Display(Name = "Page Is Active/Deactivate")]
        public bool IsActive { get; set; }

        public int NavComponentId { get; set; }

        [Required]
        public string Link { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
