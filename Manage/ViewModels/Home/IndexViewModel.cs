using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Carousels = new List<Carousel>();
            News = new List<News>();
            Projects = new List<Core.Models.Project>();
            OurBusinesses = new List<Core.Models.OurBusiness>();
        }
        public List<Carousel> Carousels { get; set; }
        public List<News> News { get; set; }
        public List<Core.Models.Project> Projects { get; set; }
        public List<Core.Models.OurBusiness> OurBusinesses { get; set; }
        public HomeVideoComponent HomeVideoComponent { get; set; }
        public SustainableDevelopment SustainableDevelopmentComponent { get; set; }
    }
}
