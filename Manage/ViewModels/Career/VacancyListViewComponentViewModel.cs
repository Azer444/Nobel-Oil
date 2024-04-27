using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Career
{
    public class VacancyListViewComponentViewModel
    {
        public VacancyListViewComponentViewModel()
        {
            Vacancies = new List<Vacancy>();
        }

        public List<Vacancy> Vacancies { get; set; }
    }
}
