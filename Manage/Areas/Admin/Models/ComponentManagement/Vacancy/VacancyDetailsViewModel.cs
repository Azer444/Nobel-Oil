using System;

namespace Manage.Areas.Admin.Models.ComponentManagement.Vacancy
{
    public class VacancyDetailsViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
