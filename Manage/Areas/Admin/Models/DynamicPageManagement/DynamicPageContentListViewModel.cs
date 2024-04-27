using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.DynamicPageManagement
{
    public class DynamicPageContentListViewModel
    {
        public List<Core.Models.DynamicPageContent> DynamicPageContents { get; set; }
        public int DynamicPageId { get; set; }

    }
}
