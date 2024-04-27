using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Media
{
    public class MediaNewsViewModel
    {
        public List<News> News { get; set; }

        public Pager Pager { get; set; }

        public string DateRange { get; set; }
    }
}
