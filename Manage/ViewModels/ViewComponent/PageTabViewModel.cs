using Core.Constants;
using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.ViewComponent
{
    public class PageTabViewModel
    {
        public List<PageTabComponent> PageTabComponents { get; set; }
        public Page Page { get; set; }
        public string CurrentPage { get; set; }
    }
}
