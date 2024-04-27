using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class LifeAtNobelEnergyPdf
    {
        public int Id { get; set; }

        public Core.Constants.Language Language { get; set; }

        [Required]
        public string PdfFileName { get; set; }

        public LifeAtNobelEnergy LifeAtNobelEnergy { get; set; }

        public int LifeAtNobelEnergyId { get; set; }
    }
}
