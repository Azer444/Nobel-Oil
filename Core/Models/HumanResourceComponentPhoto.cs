using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class HumanResourceComponentPhoto : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public int HumanResourceComponentId { get; set; }

        public HumanResourceComponent HumanResourceComponent { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
