using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class EnvironmentSubComponentPhoto : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public EnvironmentSubComponent EnvironmentSubComponent { get; set; }

        public int EnvironmentSubComponentId { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
