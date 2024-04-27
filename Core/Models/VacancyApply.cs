using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class VacancyApply
    {
        public int Id { get; set; }

        public Vacancy Vacancy { get; set; }

        public int VacancyId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        [Display(Name = "CV")]
        public string CVName { get; set; }

        [Display(Name = "Supporting Files")]
        public ICollection<VacancyApplyFile> VacancyApplyFiles { get; set; }
    }
}
