using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.OurStrategy
{
    public class OurStrategyIndexViewModel
    {
        public List<OurStrategyComponent> OurStrategyComponents { get; set; }

        public List<KeyAreaComponent> KeyAreaComponents { get; set; }
    }
}
