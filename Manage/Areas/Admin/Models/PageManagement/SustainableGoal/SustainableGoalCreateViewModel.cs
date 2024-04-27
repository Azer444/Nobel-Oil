using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.SustainableGoal
{
    public class SustainableGoalCreateViewModel
    {
        #region Title

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        #endregion

        #region ExternalLink

        public string ExternalLink_AZ { get; set; }

        public string ExternalLink_RU { get; set; }

        [Required]
        public string ExternalLink_EN { get; set; }

        public string ExternalLink_TR { get; set; }

        #endregion

        [Required]
        [FileSize]
        [FileContentType("Images")]
        [Display(Name = "Background photo")]
        public IFormFile Photo { get; set; }
    }
}
