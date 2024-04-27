using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.OurHistory
{
    public class OurHistoryEditComponentViewModel
    {
        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string ContentWWA_AZ { get; set; }

        public string ContentWWA_RU { get; set; }

        [Required]
        public string ContentWWA_EN { get; set; }

        public string ContentWWA_TR { get; set; }

        public string PhotoPath { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo { get; set; }
    }
}
