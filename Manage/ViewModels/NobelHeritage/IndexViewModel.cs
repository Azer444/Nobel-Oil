using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.NobelHeritage
{
    public class IndexViewModel
    {
        public Core.Models.NobelHeritage NobelHeritageComponent { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }
}
