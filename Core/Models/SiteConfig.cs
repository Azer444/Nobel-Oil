using Core.Models.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class SiteConfig : ITiming
    {
        public int Id { get; set; }

        [NotMapped]
        [Required]
        public IFormFile FirstLogo { get; set; }

        public string FirstLogoName { get; set; }

        public string FacebookLink { get; set; }

        public string LinkedinLink { get; set; }

        public string TwitterLink { get; set; }

        public string YoutubeLink { get; set; }

        public string Contact_AZ { get; set; }

        public string Contact_RU { get; set; }

        public string Contact_EN { get; set; }

        public string Contact_TR { get; set; }

        public string Copyright_AZ { get; set; }

        public string Copyright_RU { get; set; }

        public string Copyright_EN { get; set; }

        public string Copyright_TR { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
