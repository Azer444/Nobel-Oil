using Core.Models;
using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.PageManagement.Environment
{
    public class EnvironmentEditSubComponentViewModel
    {
        public EnvironmentEditSubComponentViewModel()
        {
            Photos = new List<IFormFile>();
        }

        public int Id { get; set; }

        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        [Required]
        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        [Required]
        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string ContentEnvironment_AZ { get; set; }

        public string ContentEnvironment_RU { get; set; }

        [Required]
        public string ContentEnvironment_EN { get; set; }

        public string ContentEnvironment_TR { get; set; }

        public bool isBanner { get; set; }

        public string PhotoName_Environment { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public IFormFile Photo_Environment { get; set; }

        [FileSize]
        [FileContentType("Images")]
        public List<IFormFile> Photos { get; set; }

        public ICollection<EnvironmentSubComponentPhoto> EnvironmentSubComponentPhotos { get; set; }
    }
}
