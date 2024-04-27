using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Media
{
    public class MediaPublicationReportComponentViewModel
    {
        public MediaPublicationReportComponentViewModel()
        {
            RecentPublicationReports = new List<PublicationReport>();
            PublicationReportPdfs = new List<PublicationReportPdf>();
        }

        public PublicationReport PublicationReport { get; set; }
        public List<PublicationReport> RecentPublicationReports { get; set; }
        public List<PublicationReportPdf> PublicationReportPdfs { get; set; }
    }
}
