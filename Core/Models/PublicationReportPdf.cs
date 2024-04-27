using Core.Models.Abstraction;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class PublicationReportPdf : ITiming
    {
        public int Id { get; set; }

        public Core.Constants.Language Language { get; set; }

        [Required]
        public string PdfFileName { get; set; }

        public PublicationReport PublicationReport { get; set; }

        public int PublicationReportId { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //
    }
}
