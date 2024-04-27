using Manage.Validations.FileContentType;
using Manage.Validations.FileSize;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.ViewModels.Career
{
    public class VacancyApplyViewComponentViewModel
    {
        public VacancyApplyViewComponentViewModel()
        {
            SupportingFiles = new List<IFormFile>();
        }

        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        public int VacancyId { get; set; }

        [Required]
        [FileSize]
        [FileContentType]
        [Display(Name = "Upload CV")]
        public IFormFile CV { get; set; }

        [Required]
        [FileSize]
        [FileContentType]
        [Display(Name = "Upload supporting files")]
        public List<IFormFile> SupportingFiles { get; set; }
    }
}
