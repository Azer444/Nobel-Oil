using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class SafetySubComponentPhoto : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public SafetySubComponent SafetySubComponent { get; set; }

        public int SafetySubComponentId { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
