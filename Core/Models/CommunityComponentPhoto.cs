using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CommunityComponentPhoto : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public int CommunityComponentId { get; set; }

        public CommunityComponent CommunityComponent { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
