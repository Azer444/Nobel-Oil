using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CompanyService : ITiming
    {
        public int Id { get; set; }

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

        [Display(Name = "Background photo")]
        public string PhotoName { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
