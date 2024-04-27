using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public string LowerName { get => Name.ToLower(); }

        public bool Enabled { get; set; }
    }
}
