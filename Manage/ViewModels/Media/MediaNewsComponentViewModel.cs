using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Media
{
    public class MediaNewsComponentViewModel
    {
        public News News { get; set; }

        public List<News> RecentNews { get; set; }
    }
}
