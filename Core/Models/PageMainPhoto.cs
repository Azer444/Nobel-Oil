using Core.Constants;
using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class PageMainPhoto : ITiming
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public Page Page { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [NotMapped]
        public string PhotoPath { get; set; }

        [Required]
        public string PhotoName { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
