using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class HomeVideoComponent : ITiming
    {
        public int Id { get; set; }

        #region Title

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        #endregion

        public string PhotoName { get; set; }
        public string VideoUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
