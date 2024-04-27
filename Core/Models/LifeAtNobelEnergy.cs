using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class LifeAtNobelEnergy
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string Description_AZ { get; set; }

        public string Description_RU { get; set; }

        [Required]
        public string Description_EN { get; set; }

        public string Description_TR { get; set; }

        public bool ShowOnHome { get; set; }

        public string PhotoName { get; set; }

        [NotMapped]
        public string PhotoPath { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public DateTime ActionDate { get; set; }

        public ICollection<LifeAtNobelEnergyPdf> LifeAtNobelEnergyPdfs { get; set; }
    }
}
