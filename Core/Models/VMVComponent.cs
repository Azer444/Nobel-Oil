using Core.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class VMVComponent : ITiming
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

        [NotMapped]
        public List<string> SplitedContent_AZ { get; set; }
        [NotMapped]
        public List<string> SplitedContent_RU { get; set; }
        [NotMapped]
        public List<string> SplitedContent_EN { get; set; }
        [NotMapped]
        public List<string> SplitedContent_TR { get; set; }

        public string ContentWWA_AZ { get; set; }

        public string ContentWWA_RU { get; set; }


        [Required]
        public string ContentWWA_EN { get; set; }

        public string ContentWWA_TR { get; set; }

        public ICollection<VMVComponentPhoto> VMVComponentPhotos { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
