using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Carousel
{
    public class CarouselEditViewModel
    {
        public int Id { get; set; }

        #region Title

        [Display(Name = "Title (AZ)")]
        public string Title_AZ { get; set; }

        [Display(Name = "Title (RU)")]
        public string Title_RU { get; set; }

        [Required]
        [Display(Name = "Title (EN)")]
        public string Title_EN { get; set; }

        [Display(Name = "Title (TR)")]
        public string Title_TR { get; set; }

        #endregion

        #region Content

        [Display(Name = "Description (AZ)")]
        public string Description_AZ { get; set; }

        [Display(Name = "Description (RU)")]
        public string Description_RU { get; set; }

        [Required]
        [Display(Name = "Description (EN)")]
        public string Description_EN { get; set; }

        [Display(Name = "Description (TR)")]
        public string Description_TR { get; set; }

        #endregion

        #region ReadMore

        [Display(Name = "Read more link")]
        public string ReadMoreLink { get; set; }

        #endregion

        [Required]
        [Display(Name = "Order")]
        public int Order { get; set; }

        [Required]
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }

        public string PhotoPath { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }
    }
}
