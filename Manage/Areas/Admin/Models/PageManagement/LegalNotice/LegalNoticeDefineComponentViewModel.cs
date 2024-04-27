using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.LegalNotice
{
    public class LegalNoticeDefineComponentViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }


        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }
    }
}
