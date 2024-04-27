using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Sustainability
{
    public class IndexViewModel
    {
        public IEnumerable<SustainabilityReport> SustainabilityReports { get; set; }
        public Pager Pager { get; set; }
    }
}
