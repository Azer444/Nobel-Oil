using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.History
{
    public class HistoryEditViewModel
    {
        public int Id { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public int Order { get; set; }

        [Display(Name = "Action Date")]
        public DateTime ActionDate { get; set; }
    }
}
