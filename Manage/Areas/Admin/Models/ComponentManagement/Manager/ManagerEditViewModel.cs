using Core.Constants;
using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.ComponentManagement.Manager
{
    public class ManagerEditViewModel
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

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        [Display(Name = "Manager type")]
        public ManagerType Type { get; set; }

        [FileSize]
        [FileContentType("Images")]
        [Display(Name = "New photo")]
        public IFormFile NewPhoto { get; set; }
    }
}
