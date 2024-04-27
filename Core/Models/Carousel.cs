using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Carousel : ITiming
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

        public string Description_AZ { get; set; }

        public string Description_RU { get; set; }

        [Required]
        public string Description_EN { get; set; }

        public string Description_TR { get; set; }

        #endregion

        #region ReadMore

        [Required]
        public string ReadMoreLink { get; set; }

        #endregion

        public int Order { get; set; }
        public bool IsActive { get; set; }

        public string PhotoName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
