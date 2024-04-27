using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.FooterViewComponent
{
    public class FooterViewComponentViewModel
    {
        public List<NavTitleComponent> NavTitleComponents { get; set; }

        public SiteConfig SiteConfig { get; set; }
    }
}
