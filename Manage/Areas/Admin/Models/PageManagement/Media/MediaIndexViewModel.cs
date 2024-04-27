using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Media
{
    public class MediaIndexViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public List<MediaComponent> MediaComponents { get; set; }
    }
}
