using Core.Constants;
using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Manager : ITiming
    {
        public int Id { get; set; }

        #region Name

        [Display(Name = "Name (AZ)")]
        public string Name_AZ { get; set; }

        [Display(Name = "Name (RU)")]
        public string Name_RU { get; set; }

        [Required]
        [Display(Name = "Name (EN)")]
        public string Name_EN { get; set; }

        [Display(Name = "Name (TR)")]
        public string Name_TR { get; set; }

        #endregion

        #region Info

        [Display(Name = "Info (AZ)")]
        public string Info_AZ { get; set; }

        [Display(Name = "Info (RU)")]
        public string Info_RU { get; set; }

        [Required]
        [Display(Name = "Info (EN)")]
        public string Info_EN { get; set; }

        [Display(Name = "Info (TR)")]
        public string Info_TR { get; set; }

        #endregion


        [Display(Name = "Content (AZ)")]
        public string Content_AZ { get; set; }

        [Display(Name = "Content (RU)")]
        public string Content_RU { get; set; }

        [Required]
        [Display(Name = "Content (EN)")]
        public string Content_EN { get; set; }

        [Display(Name = "Content (TR)")]
        public string Content_TR { get; set; }

        [Display(Name = "Phone name")]
        public string PhotoName { get; set; }

        [Display(Name = "Manager type")]
        [Column(TypeName = "nvarchar(20)")]
        public ManagerType Type { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
