using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.VMV
{
    public class VMVDefineComponentViewModel
    {
        public VMVDefineComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

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

        public string ContentWWA_AZ { get; set; }

        public string ContentWWA_RU { get; set; }

        [Required]
        public string ContentWWA_EN { get; set; }

        public string ContentWWA_TR { get; set; }

        [Required]
        [FileSize]
        [FileContentType("Images")]
        public List<IFormFile> Photos { get; set; }
    }
}
