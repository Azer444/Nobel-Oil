using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Career
{
    public class VacancyViewComponentViewModel
    {
        public VacancyViewComponentViewModel()
        {
            Vacancies = new List<Vacancy>();
        }

        public List<Vacancy> Vacancies { get; set; }
        public VacancyApplyViewComponentViewModel VacancyApply { get; set; }
    }
}
