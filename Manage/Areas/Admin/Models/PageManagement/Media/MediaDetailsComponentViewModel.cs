using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Media
{
    public class MediaDetailsComponentViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string PhotoPath { get; set; }

        public string Link { get; set; }

        [Display(Name = "Page Is Active/Deactivate")]
        public bool IsActive { get; set; }

        public bool isBanner { get; set; }
    }
}
