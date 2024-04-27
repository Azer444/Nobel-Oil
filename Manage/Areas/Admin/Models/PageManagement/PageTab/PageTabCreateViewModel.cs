using Core.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manage.Areas.Admin.Models.PageManagement.PageTab
{
    public class PageTabCreateViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Link { get; set; }

        [Required, DisplayName("Page Is Active/Deactive")]
        public bool IsActive { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Page Page { get; set; }
    }
}
