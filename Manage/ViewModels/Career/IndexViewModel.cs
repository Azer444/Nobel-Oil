using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Career
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            CareerComponents = new List<CareerComponent>();
            Companies = new List<Core.Models.Company>();
            CareerTipComponents = new List<CareerTipComponent>();
        }

        public List<CareerComponent> CareerComponents { get; set; }
        public List<Company> Companies { get; set; }
        public List<CareerTipComponent> CareerTipComponents { get; set; }
        public List<Flatpage> Flatpages { get; set; }
        public List<Core.Models.DynamicPage> DynamicPages { get; set; }
    }
}
