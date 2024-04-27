using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Project : ITiming
    {
        public int Id { get; set; }

        #region Title

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        #endregion

        #region Content

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        #endregion

        #region Description

        public string Description_AZ { get; set; }

        public string Description_RU { get; set; }

        [Required]
        public string Description_EN { get; set; }

        public string Description_TR { get; set; }

        #endregion

        public string Slug { get; set; }

        public bool ShowOnHome { get; set; }
        public string MainPhotoName { get; set; }
        public string PhotoName { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
