using Core.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class NavComponent : ITiming
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

        public NavTitleComponent NavTitleComponent { get; set; }

        public int NavTitleComponentId { get; set; }

        [Required]
        [Display(Name = "Page Is Active/Deactivate")]
        public bool IsActive { get; set; }

        public ICollection<NavSubComponent> NavSubComponents { get; set; }

        public string Link { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
