using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Company : ITiming
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        #region Title Career

        public string TitleCareer_AZ { get; set; }

        public string TitleCareer_RU { get; set; }

        [Required]
        public string TitleCareer_EN { get; set; }

        public string TitleCareer_TR { get; set; }

        #endregion
        public string Link_Career { get; set; }

        [Required]
        public string Slug { get; set; }


        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string ContentWWD_AZ { get; set; }

        public string ContentWWD_RU { get; set; }

        [Required]
        public string ContentWWD_EN { get; set; }

        public string ContentWWD_TR { get; set; }


        [NotMapped]
        public string PhotoPath { get; set; }

        public string PhotoName { get; set; }

        public string PhotoName_WWD { get; set; }

        public string PhotoName_Career { get; set; }

        public bool ShowOnCareer { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
