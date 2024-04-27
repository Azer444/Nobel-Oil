using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class NobelHeritagePhoto : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PhotoName { get; set; }

        public int NobelHeritageId { get; set; }
        public NobelHeritage NobelHeritage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
