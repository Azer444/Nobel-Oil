using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Media
{
    public class MediaPublicationReportViewModel
    {
        public List<PublicationReport> PublicationReports { get; set; }

        public Pager Pager { get; set; }
    }
}
