﻿using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CorporateGovernanceComponent : ITiming
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }


        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string ContentWWA_AZ { get; set; }

        public string ContentWWA_RU { get; set; }

        [Required]
        public string ContentWWA_EN { get; set; }

        public string ContentWWA_TR { get; set; }

        [Required]
        public string PhotoName_WWA { get; set; }

        [Required]
        public string PhotoName { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
