using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.WhoWeAre
{
    public class IndexViewModel
    {
        public AboutComponent AboutComponent { get; set; }
        public VMVComponent VMVComponent { get; set; }
        public Core.Models.NobelHeritage NobelHeritage { get; set; }
        public OurHistoryComponent OurHistoryComponent { get; set; }
        public CorporateGovernanceComponent CorporateGovernanceComponent { get; set; }
        public List<Flatpage> Flatpages { get; set; }
        public List<Core.Models.DynamicPage> DynamicPages { get; set; }
    }
}
