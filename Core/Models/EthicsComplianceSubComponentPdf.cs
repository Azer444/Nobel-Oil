using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class EthicsComplianceSubComponentPdf : ITiming
    {
        public int Id { get; set; }

        [Required]
        public string PdfFileName { get; set; }

        public EthicsComplianceSubComponent EthicsComplianceSubComponent { get; set; }

        public int EthicsComplianceSubComponentId { get; set; }

        [Required]
        public Core.Constants.Language Language { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
