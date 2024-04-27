using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Media
{
    public class MediaIndexViewModel
    {
        public List<News> News { get; set; }
        public List<MediaComponent> MediaComponents { get; set; }
        public List<Flatpage> Flatpages { get; set; }
        public List<Core.Models.DynamicPage> DynamicPages { get; set; }
    }
}
