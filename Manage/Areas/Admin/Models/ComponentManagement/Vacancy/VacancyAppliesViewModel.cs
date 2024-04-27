using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.ComponentManagement.Vacancy
{
    public class VacancyAppliesViewModel
    {
        public Core.Models.Vacancy Vacancy { get; set; }
        public List<VacancyApply> VacancyApplies { get; set; }
    }
}
