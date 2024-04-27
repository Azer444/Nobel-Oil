using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class VacancyApplyFile
    {
        public int Id { get; set; }

        public VacancyApply VacancyApply { get; set; }

        public int VacancyApplyId { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
