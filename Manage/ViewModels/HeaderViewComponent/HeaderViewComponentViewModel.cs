using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.HeaderViewComponent
{
    public class HeaderViewComponentViewModel
    {
        public List<NavTitleComponent> NavTitleComponents { get; set; }

        public SiteConfig SiteConfig { get; set; }

        public Core.Models.Search.Search Search { get; set; }
    }
}
