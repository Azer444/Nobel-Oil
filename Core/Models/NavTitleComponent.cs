using Core.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class NavTitleComponent : ITiming
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

        [Required]
        public string Link { get; set; }

        [Display(Name = "Show only on footer")]
        public bool ShowOnlyOnFooter { get; set; }

        public int Order { get; set; }

        public ICollection<NavComponent> NavComponents { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
