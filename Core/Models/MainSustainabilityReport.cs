using Core.Models.Abstraction;
using System;

namespace Core.Models
{
    public class MainSustainabilityReport : ITiming
    {
        public int Id { get; set; }
        public string Title_AZ { get; set; }
        public string Title_RU { get; set; }
        public string Title_EN { get; set; }
        public string Title_TR { get; set; }
        public string Content_AZ { get; set; }
        public string Content_RU { get; set; }
        public string Content_EN { get; set; }
        public string Content_TR { get; set; }
        public string PhotoName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
