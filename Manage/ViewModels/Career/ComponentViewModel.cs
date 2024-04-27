using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Career
{
    public class ComponentViewModel
    {
        public ComponentViewModel()
        {
            Vacancies = new List<Vacancy>();
        }

        public CareerComponent CareerComponent { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public VacancyApplyViewComponentViewModel VacancyApply { get; set; }

    }
}
